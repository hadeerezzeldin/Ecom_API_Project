using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.DTO.Photo
{
   public record PhotoDTO
    {
        
            public string image { get; set; }
            public int productId { get; set; }
        
    }
}
