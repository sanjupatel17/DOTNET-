using Inventory17.DTOs;

namespace Inventory17.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> GetById(int id);
        Task<ProductDTO> Add(CreateProductDTO dto);
        Task Update(int id, CreateProductDTO dto);
        Task Delete(int id);
    }
}