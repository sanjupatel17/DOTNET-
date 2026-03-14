using Microsoft.AspNetCore.Mvc;
using Assignment18.Data;
using Assignment18.Models;
using Assignment18.DTOs;

namespace Assignment18.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowRecordController : ControllerBase
{
    private readonly AppDbContext _context;

    public BorrowRecordController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecord(BorrowRecordDto dto)
    {
        var record = new BorrowRecord
        {
            BorrowerName = dto.BorrowerName,
            BorrowDate = dto.BorrowDate,
            BookId = dto.BookId
        };

        _context.BorrowRecords.Add(record);
        await _context.SaveChangesAsync();

        return Ok(dto);
    }
}