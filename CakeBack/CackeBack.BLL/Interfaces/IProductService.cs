using CakeBack.Models.VModels.CategoryDTO;
using CakeBack.Models.VModels.SubCategoryDTO;

namespace CackeBack.BLL.Interfaces
{
    public interface IProductService
    {
        // Category 
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<CategoryDTO> AddCategoryAsync(CategoryCreationDTO category);
        Task UpdateCategoryAsync(int id, CategoryCreationDTO category);
        Task<bool> DeleteCategoryAsync(int id);


        // SubCategory 
        Task<IEnumerable<SubCategoryDTO>> GetAllSubCategoriesAsync();
        Task<SubCategoryDTO> GetSubCategoryByIdAsync(int id);
        Task<SubCategoryDTO> AddSubCategoryAsync(SubCategoryCreationDTO subCategory);
        Task UpdateSubCategoryAsync(int id, SubCategoryCreationDTO subCategory);
        Task<bool> DeleteSubCategoryAsync(int id);
    }
}
