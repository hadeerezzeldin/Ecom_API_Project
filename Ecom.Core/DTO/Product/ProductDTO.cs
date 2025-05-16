using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.DTO.Photo;
using Ecom.Core.Models;

namespace Ecom.Core.DTO.Product
{
   public record  ProductDTO
    {
            public string ProductName { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string CategoryNaame { get; set; }
            public virtual List<PhotoDTO> Photos { get; set; } = new List<PhotoDTO>();
        }

       
    
}
