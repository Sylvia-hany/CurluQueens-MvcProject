using CurlyQueens.Repository;
using CurlyQueens.ViewModels;
using Newtonsoft.Json;

namespace CurlyQueens.Services
{
    public class CartService : ICartService
    {
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CartSessionKey = "ShoppingCart";

        public CartService(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public CartViewModel GetCart()
        {
            var cartJson = Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new CartViewModel();
            }
            return JsonConvert.DeserializeObject<CartViewModel>(cartJson) ?? new CartViewModel();
        }

        private void SaveCart(CartViewModel cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            Session.SetString(CartSessionKey, cartJson);
        }

        public void AddToCart(int productId, int quantity = 1)
        {
            var cart = GetCart();
            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var product = _productRepository.GetByIdAsync(productId).Result;
                if (product != null)
                {
                    cart.Items.Add(new CartItemViewModel
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Price = product.Price,
                        Quantity = quantity,
                        ImageUrl = product.ImageUrl ?? "/images/default.jpg"
                    });
                }
            }

            SaveCart(cart);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                cart.Items.Remove(item);
                SaveCart(cart);
            }
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var cart = GetCart();
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                if (quantity > 0)
                {
                    item.Quantity = quantity;
                }
                else
                {
                    cart.Items.Remove(item);
                }
                SaveCart(cart);
            }
        }

        public void ClearCart()
        {
            Session.Remove(CartSessionKey);
        }

        public int GetCartItemCount()
        {
            var cart = GetCart();
            return cart.GetItemCount();
        }
    }
}
