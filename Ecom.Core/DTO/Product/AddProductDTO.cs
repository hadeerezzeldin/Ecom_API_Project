using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ecom.Core.DTO.Product
{
    public record AddProductDTO
    {
        public string ProductName { get; set; }
       
        public string Description { get; set; }
        public decimal OldPrice { get; set; }

        public decimal NewPrice { get; set; }
        public int Quantity { get; set; }
        public int categoryId { get; set; }
        public IFormFileCollection Photo { get; set; }
    }
}
