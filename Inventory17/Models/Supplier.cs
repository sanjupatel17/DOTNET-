namespace Inventory17.Models;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<ProductSupplier> ProductSuppliers { get; set; }
}