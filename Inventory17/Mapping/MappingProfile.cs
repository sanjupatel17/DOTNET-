using AutoMapper;
using Inventory17.Models;
using Inventory17.DTOs;

namespace Inventory17.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // =========================
            // PRODUCT MAPPINGS
            // =========================

            // Entity → Response DTO
            CreateMap<Product, ProductDTO>();

            // Create DTO → Entity
            CreateMap<CreateProductDTO, Product>();


            // =========================
            // CATEGORY MAPPINGS
            // =========================

            // Entity → Response DTO
            CreateMap<Category, CategoryDTO>();

            // Create DTO → Entity
            CreateMap<CreateCategoryDTO, Category>();
        }
    }
}