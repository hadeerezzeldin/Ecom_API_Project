﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string image { get; set; }
        public int productId { get; set; }
        [ForeignKey(nameof(productId))]
        public virtual Product Product { get; set; }
    }
}
