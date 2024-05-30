using CackeBack.BLL.Interfaces;
using CackeBack.DAL.Interface;
using CakeBack.Models.Utilidades;
using CakeBack.Models.VModels.CategoryDTO;
using CakeBack.Models.VModels.SubCategoryDTO;

namespace CackeBack.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly MappingProfile _mapper;

        public ProductService(IProductRepository productRepository, MappingProfile mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // Category methods
        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _productRepository.GetAllCategoriesAsync();
            return categories.Select(category => _mapper.MapToCategoryDTO(category));
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _productRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return null;
            }
            return _mapper.MapToCategoryDTO(category);
        }

        public async Task<CategoryDTO> AddCategoryAsync(CategoryCreationDTO category)
        {
            var categoryEntity = _mapper.MapToCategory(category);
            await _productRepository.AddCategoryAsync(categoryEntity);
            return _mapper.MapToCategoryDTO(categoryEntity);
        }

        public async Task UpdateCategoryAsync(int id, CategoryCreationDTO category)
        {
            var categoryEntity = await _productRepository.GetCategoryByIdAsync(id);
            if (categoryEntity == null)
            {
                throw new Exception("Category not found");
            }
            _mapper.MapToCategory(category, categoryEntity);
            await _productRepository.UpdateCategoryAsync(categoryEntity);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _productRepository.DeleteCategoryAsync(id);
        }

        // SubCategory methods
        public async Task<IEnumerable<SubCategoryDTO>> GetAllSubCategoriesAsync()
        {
            var subCategories = await _productRepository.GetAllSubCategoriesAsync();
            return subCategories.Select(subCategory => _mapper.MapToSubCategoryDTO(subCategory));
        }

        public async Task<SubCategoryDTO> GetSubCategoryByIdAsync(int id)
        {
            var subCategory = await _productRepository.GetSubCategoryByIdAsync(id);
            if (subCategory == null)
            {
                return null;
            }
            return _mapper.MapToSubCategoryDTO(subCategory);
        }

        public async Task<SubCategoryDTO> AddSubCategoryAsync(SubCategoryCreationDTO subCategory)
        {
            var subCategoryEntity = _mapper.MapToSubCategory(subCategory);
            await _productRepository.AddSubCategoryAsync(subCategoryEntity);
            return _mapper.MapToSubCategoryDTO(subCategoryEntity);
        }

        public async Task UpdateSubCategoryAsync(int id, SubCategoryCreationDTO subCategory)
        {
            var subCategoryEntity = await _productRepository.GetSubCategoryByIdAsync(id);
            if (subCategoryEntity == null)
            {
                throw new Exception("SubCategory not found");
            }
            _mapper.MapToSubCategory(subCategory, subCategoryEntity);
            await _productRepository.UpdateSubCategoryAsync(subCategoryEntity);
        }

        public async Task<bool> DeleteSubCategoryAsync(int id)
        {
            return await _productRepository.DeleteSubCategoryAsync(id);
        }
    }
}
