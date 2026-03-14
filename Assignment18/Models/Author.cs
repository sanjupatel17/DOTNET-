using System.ComponentModel.DataAnnotations;

namespace Assignment18.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Country { get; set; }

    public ICollection<Book>? Books { get; set; }
}