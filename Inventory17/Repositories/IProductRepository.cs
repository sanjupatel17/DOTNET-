using Inventory17.Models;

namespace Inventory17.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(int id);
    Task<Product> Add(Product product);
    Task Update(Product product);
    Task Delete(Product product);
}