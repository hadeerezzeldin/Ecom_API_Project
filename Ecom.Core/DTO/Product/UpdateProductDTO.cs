using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.DTO.Product
{
    public record UpdateProductDTO :AddProductDTO
    {
        public int Id { get; set; }

    }
}
