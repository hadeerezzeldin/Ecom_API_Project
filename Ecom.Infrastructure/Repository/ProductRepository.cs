using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Interfaces;
using Ecom.Core.Models;
using Ecom.Infrastructure.Data;

namespace Ecom.Infrastructure.Repository
{
    public class ProductRepository : IGenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository( AppDbContext context)
        {
            this.context = context;
        }
        public Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
