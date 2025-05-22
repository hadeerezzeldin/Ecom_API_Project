using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Models
{
   public class Cart
    {
        public Cart()
        {

        }
        public Cart(string id)
        {
             this.Id = id;

        }
        public string Id { get; set; }
        public List<CartItem> cartItem { get; set; } = new List<CartItem>();
    }
}
