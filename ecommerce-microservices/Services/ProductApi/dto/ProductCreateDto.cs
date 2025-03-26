using ProductApi.Enums;

namespace ProductApi.dto
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public Category Category { get; set; }

        public IFormFile Image { get; set; }  // Cloudinary'e yüklenecek görsel
    }
}
