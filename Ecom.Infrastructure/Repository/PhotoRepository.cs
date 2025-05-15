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
    public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
    {
        private readonly AppDbContext context;

        public PhotoRepository(AppDbContext context) :base(context)
        {
            this.context = context;
        }
        
    }
}
