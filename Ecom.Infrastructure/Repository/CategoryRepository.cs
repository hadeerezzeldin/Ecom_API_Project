using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Interfaces;
using Ecom.Core.Models;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Infrastructure.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
       public readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)  :base(context)
        {
            //this.context = context;
        }
      

        //public async Task<List<Category>> GetAllCategoryWithProducts()
        //{
        //    return await context.Categories.Include(c => c.products)
        //        .ToListAsync();
        //}
    }
}
