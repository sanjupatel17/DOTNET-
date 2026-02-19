using ProductManagementAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ProductManagementAPI.Services
{
    public class ProductService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<ProductService> _logger;

        private static List<Product> products = new List<Product>
        {
            new Product{ Id=1, Name="Laptop", Price=50000 },
            new Product{ Id=2, Name="Mobile", Price=20000 }
        };

        public ProductService(IMemoryCache cache, ILogger<ProductService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public List<Product> GetAll()
        {
            string key = "productList";

            if (!_cache.TryGetValue(key, out List<Product> productList))
            {
                _logger.LogInformation("Cache Miss - Fetching from List");

                productList = products;

                _cache.Set(key, productList,
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
            }
            else
            {
                _logger.LogInformation("Cache Hit");
            }

            return productList;
        }

        public Product GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                throw new ProductNotFoundException("Product not found");

            return product;
        }
    }
}
