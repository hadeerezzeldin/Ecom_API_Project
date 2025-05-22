using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Models;

namespace Ecom.Core.Interfaces
{
    public interface ICartReository
    {

        Task<Cart> GetBasketAsync(string basketId);
        Task<Cart> UpdateBasketAsync(Cart cart);    
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
