using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using Microsoft.Extensions.Configuration;


namespace Ecom.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
       
        private readonly IImageManagmentService imageManagmentService;

        public ICategoryRepository categoryRepository { get; }

        public IProductRepository productRepository { get; }

        public IPhotoRepository photoRepository { get; }

        public ICartReository cartReository { get; }

        public UnitOfWork(AppDbContext context, IImageManagmentService imageManagmentService, IMapper mapper )
        {
            this.context = context;
            this.mapper = mapper;
            
            categoryRepository = new CategoryRepository(context);
            productRepository = new ProductRepository(context , mapper ,imageManagmentService);
            photoRepository = new PhotoRepository(context);
            this.imageManagmentService = imageManagmentService;
            cartReository = new FakeCartRepository();
        }
    }
}
