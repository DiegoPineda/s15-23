using CackeBack.DAL.Dbcontext;
using CackeBack.DAL.Interface;
using CakeBack.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CackeBack.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CakeDbContext _context;

        public ProductRepository(CakeDbContext context)
        {
            _context = context;
        }

        // Category methods
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        // SubCategory methods
        public async Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync()
        {
            return await _context.SubCategories.ToListAsync();
        }

        public async Task<SubCategory> GetSubCategoryByIdAsync(int id)
        {
            return await _context.SubCategories.FindAsync(id);
        }

        public async Task AddSubCategoryAsync(SubCategory subCategory)
        {
            await _context.SubCategories.AddAsync(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubCategoryAsync(SubCategory subCategory)
        {
            _context.SubCategories.Update(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteSubCategoryAsync(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null)
            {
                return false;
            }

            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
