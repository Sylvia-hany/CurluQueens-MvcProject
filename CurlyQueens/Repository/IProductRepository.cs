using CurlyQueens.Models;

namespace CurlyQueens.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // دوال مخصصة للـ Product
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
        Task<Product?> GetProductWithCategoryAsync(int productId);
        Task<IEnumerable<Product>> GetTopProductsAsync(int count);
        Task<IEnumerable<Product>> GetProductsPagedAsync(int page, int pageSize);
        Task<int> CountProductsAsync();
    }
}
