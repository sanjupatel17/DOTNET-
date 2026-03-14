using Microsoft.AspNetCore.Mvc;
using Inventory17.Data;          // ✅ IMPORTANT FIX
using Inventory17.DTOs;
using Inventory17.Models;

namespace Inventory17.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // CREATE CATEGORY
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        // GET ALL CATEGORIES
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _context.Categories
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

            return Ok(categories);
        }
    }
}