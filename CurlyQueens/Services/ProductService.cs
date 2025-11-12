using AutoMapper;
using CurlyQueens.Models;
using CurlyQueens.Repository;
using CurlyQueens.ViewModel;

namespace CurlyQueens.Services
{


    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        //for product details
        public async Task<ProductViewModel?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductWithCategoryAsync(id);
            return _mapper.Map<ProductViewModel?>(product);
        }

        public async Task<IEnumerable<ProductViewModel>> SearchProductsAsync(string searchTerm)
        {
            var products = await _productRepository.SearchProductsAsync(searchTerm);
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }


        public async Task<IEnumerable<ProductViewModel>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public async Task<IEnumerable<ProductViewModel>> GetTopProductsAsync(int count)
        {
            var products = await _productRepository.GetTopProductsAsync(count);
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsPagedAsync(int page, int pageSize)
        {
            var products = await _productRepository.GetProductsPagedAsync(page, pageSize);
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        //for pagination
        public async Task<int> CountProductsAsync()
        {
            return await _productRepository.CountProductsAsync();
        }

        //for adding new product by admin
        public async Task AddProductAsync(ProductViewModel model)
        {
            var product = _mapper.Map<Product>(model);
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
        }

    }
}
    

