using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Services;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService service, ILogger<ProductController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Fetching all products");
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Fetching product {id}", id);
            return Ok(_service.GetById(id));
        }

        // FILE UPLOAD
        [HttpPost("upload-image/{id}")]
        public async Task<IActionResult> UploadImage(int id, IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var filePath = Path.Combine(path, file.FileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            _logger.LogInformation("Image uploaded for Product {id}", id);

            return Ok("Image Uploaded");
        }

      
        [HttpGet("download-image/{fileName}")]
        public IActionResult DownloadImage(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

            if (!System.IO.File.Exists(path))
                return NotFound();

            var bytes = System.IO.File.ReadAllBytes(path);

            _logger.LogInformation("Image downloaded {fileName}", fileName);

            return File(bytes, "application/octet-stream", fileName);
        }
    }
}
