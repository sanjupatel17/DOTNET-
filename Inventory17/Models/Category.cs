using System.Net.Http.Headers;

namespace Inventory17.Models;
public class Category
{
    public int Id { get; set; }
    public string  Name  { get; set; }

    public ICollection<Product> Products {get; set;}
}