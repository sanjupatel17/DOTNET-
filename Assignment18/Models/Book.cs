using System.ComponentModel.DataAnnotations;

namespace Assignment18.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public int AuthorId { get; set; }

    public Author? Author { get; set; }

    public ICollection<BorrowRecord>? BorrowRecords { get; set; }
}