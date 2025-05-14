using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace Ecom.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public ICategoryRepository categoryRepository { get; }

        public IProductRepository productRepository { get; }

        public IPhotoRepository photoRepository { get; }
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            categoryRepository = new CategoryRepository(context);
            productRepository = new ProductRepository(context);
            photoRepository = new PhotoRepository(context);


        }
    }
}
