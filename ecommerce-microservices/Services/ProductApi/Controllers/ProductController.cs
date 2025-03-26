using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.dto;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly ImageService _imageService;

        public ProductController(ProductService productService, ImageService imageService)
        {
            _productService = productService;
            _imageService = imageService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateDto dto)
        {
            if (dto.Image == null || dto.Image.Length == 0)
                return BadRequest(ResponseDto<string>.FailResponse("Ürün görseli zorunludur."));

            var uploadResult = await _imageService.UploadImageAsync(dto.Image);
            if (uploadResult == null)
                return StatusCode(500, ResponseDto<string>.FailResponse("Görsel yüklenemedi."));

            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Rating = dto.Rating,
                Category = dto.Category,
                ImageUrl = uploadResult
            };

            var result = await _productService.AddAsync(product);

            var productDto = new ProductDto
            {
                Id = result.Id,
                Name = result.Name,
                Price = result.Price,
                Rating = result.Rating,
                Category = result.Category.ToString(),
                ImageUrl = result.ImageUrl
            };

            return Ok(ResponseDto<ProductDto>.SuccessResponse(productDto, "Ürün başarıyla oluşturuldu."));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound(ResponseDto<string>.FailResponse("Ürün bulunamadı."));

            var dto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Rating = product.Rating,
                Category = product.Category.ToString(),
                ImageUrl = product.ImageUrl
            };

            return Ok(ResponseDto<ProductDto>.SuccessResponse(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            var productDtos = products.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Rating = product.Rating,
                Category = product.Category.ToString(),
                ImageUrl = product.ImageUrl
            }).ToList();

            return Ok(ResponseDto<List<ProductDto>>.SuccessResponse(productDtos));
        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var products = await _productService.GetByCategoryAsync(categoryId);

            var productDtos = products.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Rating = product.Rating,
                Category = product.Category.ToString(),
                ImageUrl = product.ImageUrl
            }).ToList();

            return Ok(ResponseDto<List<ProductDto>>.SuccessResponse(productDtos));
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest(ResponseDto<string>.FailResponse("Geçersiz ürün ID."));

            var deleted = await _productService.DeleteAsync(id);
            if (!deleted)
                return NotFound(ResponseDto<string>.FailResponse("Ürün bulunamadı."));

            return Ok(ResponseDto<string>.SuccessResponse(null, "Ürün başarıyla silindi."));
        }
    }
}
