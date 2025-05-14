using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Models;

namespace Ecom.Core.Interfaces
{
    public interface IProductRepository :IGenericRepository<Product>
    {
        //specific func for prod
    }
}
