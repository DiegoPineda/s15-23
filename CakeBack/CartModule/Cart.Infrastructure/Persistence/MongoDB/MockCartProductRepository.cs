using Cart.Domain.Models;
using Cart.Domain.Repositories;

namespace Cart.Infrastructure.Persistence.MongoDB;

public class MockCartRepository : ICartProductRespository
{
    static private readonly List<CartProduct> products = new List<CartProduct>();
    public async Task AddAsync(CartProduct cartProduct)
    {
        await Task.Run(() =>
        {
            products.Add(cartProduct);
        });
    }

    public async Task DeleteAsync(CartProduct cartProduct)
    {
        await Task.Run(() =>
        {
            products.Remove(cartProduct);
        });
    }

    public async Task DeleteByIdAsync(Guid cartProductId)
    {
        CartProduct? product = products.FirstOrDefault(p => p.Id == cartProductId);
        if (product == null)
        {
            return;
        }
        await DeleteAsync(product);
    }

    public async Task DeleteManyByUserIdAsync(int userId)
    {
        await Task.Run(() =>
        {
            products.RemoveAll(p => p.UserId == userId);
        });
    }

    public async Task<CartProduct?> FindByProductIdAndUserIdAsync(int userId, int productId)
    {
        return await Task.Run(() =>
        {
            return products.FirstOrDefault(p => p.ProductId == productId && p.UserId == userId);
        });
    }

    public async Task<List<CartProduct>> FindByUserIdAsync(int userId)
    {
        return await Task.Run(() =>
        {
            return products.Where(p => p.UserId == userId).ToList();
        });
    }

    public async Task UpdateAsync(CartProduct cartProduct)
    {
        await Task.Run(() =>
        {
            int index = products.IndexOf(cartProduct);
            products.Insert(index, cartProduct);
        });
    }
}