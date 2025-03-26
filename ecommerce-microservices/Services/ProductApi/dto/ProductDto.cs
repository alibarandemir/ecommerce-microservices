﻿namespace ProductApi.dto
{
    public class ProductDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public string Category { get; set; } // Enum yerine string
        public string ImageUrl { get; set; }
    }
}
