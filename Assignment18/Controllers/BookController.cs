using Microsoft.AspNetCore.Mvc;
using Assignment18.Data;
using Assignment18.Models;
using Assignment18.DTOs;

namespace Assignment18.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(BookDto dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            AuthorId = dto.AuthorId
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return Ok(dto);
    }
}