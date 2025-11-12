using CurlyQueens.Models;
using CurlyQueens.ViewModel;

namespace CurlyQueens.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel?> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductViewModel>> SearchProductsAsync(string searchTerm);
        Task<IEnumerable<ProductViewModel>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<ProductViewModel>> GetTopProductsAsync(int count);
        Task<IEnumerable<ProductViewModel>> GetProductsPagedAsync(int page, int pageSize);
        Task AddProductAsync(ProductViewModel model);

        Task<int> CountProductsAsync();
    }
}
