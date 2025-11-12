using CurlyQueens.Data;
using CurlyQueens.Models;
using Microsoft.EntityFrameworkCore;

namespace CurlyQueens.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository

    {
        public ProductRepository(MyAppdbcontext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet
                         .Where(p => p.CategoryId == categoryId)
                         .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            return await _dbSet
                         .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
                         .ToListAsync();
        }

        public async Task<Product?> GetProductWithCategoryAsync(int productId)
        {
            return await _dbSet
                         .Include(p => p.Category)
                         .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetTopProductsAsync(int count)
        {
            return await _dbSet
                         .OrderByDescending(p => p.Id) // ممكن تعدلي حسب معيار التقييم أو المبيعات لاحقًا
                         .Take(count)
                         .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsPagedAsync(int page, int pageSize)
        {
            return await _dbSet
                         .Skip((page - 1) * pageSize)
                         .Take(pageSize)
                         .ToListAsync();
        }

        public async Task<int> CountProductsAsync()
        {
            return await _dbSet.CountAsync();
        }
    }
}


