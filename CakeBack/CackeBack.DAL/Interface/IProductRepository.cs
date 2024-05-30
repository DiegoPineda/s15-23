using CakeBack.Models.Entidades;

namespace CackeBack.DAL.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);



        Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync();
        Task<SubCategory> GetSubCategoryByIdAsync(int id);
        Task AddSubCategoryAsync(SubCategory subCategory);
        Task UpdateSubCategoryAsync(SubCategory subCategory);
        Task<bool> DeleteSubCategoryAsync(int id);
    }
}
