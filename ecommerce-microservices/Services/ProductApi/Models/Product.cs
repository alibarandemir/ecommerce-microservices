﻿using ProductApi.Enums;

namespace ProductApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
