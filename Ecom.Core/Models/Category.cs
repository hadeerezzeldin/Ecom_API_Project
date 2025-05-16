using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Core.Models
{
    public class Category
    {

       
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        //public ICollection<Product> products { get; set; } = new List<Product>();

    }
}
