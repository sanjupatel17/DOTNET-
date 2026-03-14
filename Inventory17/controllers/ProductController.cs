using Microsoft.AspNetCore.Mvc;
using Inventory17.Services;
using Inventory17.DTOs;

namespace Inventory17.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAll();
            return Ok(products);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _service.GetById(id);
            return Ok(product);
        }

        // ✅ CREATE (FIXED — NO ID INSERT)
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO dto)
        {
            var result = await _service.Add(dto);
            return Ok(result);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateProductDTO dto)
        {
            await _service.Update(id, dto);
            return Ok();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}