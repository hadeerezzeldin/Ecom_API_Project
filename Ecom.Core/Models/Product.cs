using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required] 
        public string  ProductName{ get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int categoryId { get; set; }
        [ForeignKey(nameof(categoryId))]
        public virtual Category category { get; set; }
        public  virtual List<Photo> Photos { get; set; } = new List<Photo>();
    }
}
