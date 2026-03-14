using AutoMapper;
using Inventory17.DTOs;
using Inventory17.Models;
using Inventory17.Repositories;

namespace Inventory17.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET ALL
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var data = await _repo.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(data);
        }

        // GET BY ID
        public async Task<ProductDTO> GetById(int id)
        {
            var product = await _repo.GetById(id);
            return _mapper.Map<ProductDTO>(product);
        }

        // ✅ ADD PRODUCT (FIXED)
        public async Task<ProductDTO> Add(CreateProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);

            var result = await _repo.Add(product);

            return _mapper.Map<ProductDTO>(result);
        }

        // UPDATE
        public async Task Update(int id, CreateProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            product.Id = id;

            await _repo.Update(product);
        }

        // DELETE
        public async Task Delete(int id)
        {
            var product = await _repo.GetById(id);

            if (product != null)
                await _repo.Delete(product);
        }
    }
}