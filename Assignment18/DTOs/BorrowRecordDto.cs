namespace Assignment18.DTOs;

public class BorrowRecordDto
{
    public string BorrowerName { get; set; } = string.Empty;
    public DateTime BorrowDate { get; set; }
    public int BookId { get; set; }
}