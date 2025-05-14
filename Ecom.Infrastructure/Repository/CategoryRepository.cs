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
    public class CategoryRepository : IGenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository( AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Category entity)
        {
                 context.Categories.Add(entity); 
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
