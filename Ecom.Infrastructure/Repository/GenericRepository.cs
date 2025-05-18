﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();   
        }

      

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
             context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await context.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetAllWithIncludesAsync(params Expression<Func<T , object>>[] includes)
        {
          var query =context.Set<T>().AsQueryable();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return await query.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            return entity;
        }
      public async Task <T?> GetByIdWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().AsQueryable();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
             var result = await query.FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);
             return result;
        }

        public async Task UpdateAsync(T entity)
        {
         context.Entry(entity).State = EntityState.Modified;    
            await context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await  context.Set<T>().CountAsync();
        }
    }
}
