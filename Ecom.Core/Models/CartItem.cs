﻿namespace Ecom.Core.Models
{
    public class CartItem
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public  string Category { get; set; }



    }
}