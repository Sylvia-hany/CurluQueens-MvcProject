using CurlyQueens.ViewModels;

namespace CurlyQueens.Services
{
    public interface ICartService
    {
        CartViewModel GetCart();
        void AddToCart(int productId, int quantity = 1);
        void RemoveFromCart(int productId);
        void UpdateQuantity(int productId, int quantity);
        void ClearCart();
        int GetCartItemCount();
    }
}
