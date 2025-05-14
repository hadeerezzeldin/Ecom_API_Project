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
    public class PhotoRepository : IGenericRepository<Photo>, IPhotoRepository
    {
        private readonly AppDbContext context;

        public PhotoRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Task AddAsync(Photo entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Photo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Photo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Photo entity)
        {
            throw new NotImplementedException();
        }
    }
}
