using Microsoft.AspNetCore.Mvc;
using Assignment18.Data;
using Assignment18.Models;
using Assignment18.DTOs;

namespace Assignment18.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthorController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor(AuthorDto dto)
    {
        var author = new Author
        {
            Name = dto.Name,
            Country = dto.Country
        };

        _context.Authors.Add(author);
        await _context.SaveChangesAsync();

        return Ok(dto);
    }
}