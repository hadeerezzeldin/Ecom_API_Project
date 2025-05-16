using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecom.Core.DTO.Product;
using Ecom.Core.Interfaces;
using Ecom.Core.Models;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ecom.Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IImageManagmentService imageManagmentService;

        public ProductRepository(AppDbContext context, IMapper mapper , IImageManagmentService imageManagmentService) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.imageManagmentService = imageManagmentService;
        }

        public  async Task<bool> AddAsync(AddProductDTO productDTO)
        {
            if (productDTO == null) return false;

                 var product  =   mapper.Map<Product>(productDTO);
                 await context.Products.AddAsync(product);
                  await context.SaveChangesAsync();

            var imagePath =  await imageManagmentService.AddImageAsync(productDTO.Photo , productDTO.ProductName);
            var photo = imagePath.Select( path=> new Photo
            {
              image = path,
              productId = product.Id
            }).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }

       

        public async Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            if(updateProductDTO == null) return false;
            var findProduct  = await context.Products.Include(x=>x.category).Include(x => x.Photos)
                .FirstOrDefaultAsync(x => x.Id == updateProductDTO.Id);
            if(findProduct == null) return false;
            mapper.Map(updateProductDTO, findProduct);
            var findPhoto = await context.Photos.Where(x => x.productId == findProduct.Id).ToListAsync();
            foreach (var item in findPhoto)
            {
                 imageManagmentService.DeleteImageAsync(item.image);
            }
            context.Photos.RemoveRange(findPhoto);
            var imagePath = await imageManagmentService.AddImageAsync(updateProductDTO.Photo, updateProductDTO.ProductName);
            var photo = imagePath.Select(path => new Photo
            {
                image = path,
                productId = updateProductDTO.Id
            }).ToList();
             await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(Product product)
        {
            var photo = await context.Photos.Where(x => x.productId == product.Id)
                .ToListAsync();
            foreach (var item in photo)
            {
                imageManagmentService.DeleteImageAsync(item.image);
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
