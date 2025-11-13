using CurlyQueens.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurlyQueens.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // GET: /Cart/Index
        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        // POST: /Cart/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            _cartService.AddToCart(productId, quantity);
            
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                // AJAX request - return JSON
                return Json(new 
                { 
                    success = true, 
                    cartItemCount = _cartService.GetCartItemCount(),
                    message = "Product added to cart successfully!" 
                });
            }
            
            TempData["Success"] = "Product added to cart successfully!";
            return RedirectToAction("Index", "Product");
        }

        // POST: /Cart/RemoveFromCart
        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            _cartService.RemoveFromCart(productId);
            
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new 
                { 
                    success = true, 
                    cartItemCount = _cartService.GetCartItemCount() 
                });
            }
            
            TempData["Success"] = "Product removed from cart";
            return RedirectToAction("Index");
        }

        // POST: /Cart/UpdateQuantity
        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            _cartService.UpdateQuantity(productId, quantity);
            
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                var cart = _cartService.GetCart();
                var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
                return Json(new 
                { 
                    success = true, 
                    subTotal = item?.SubTotal ?? 0,
                    total = cart.GetTotal(),
                    cartItemCount = cart.GetItemCount()
                });
            }
            
            return RedirectToAction("Index");
        }

        // POST: /Cart/Clear
        [HttpPost]
        public IActionResult Clear()
        {
            _cartService.ClearCart();
            TempData["Success"] = "Cart cleared successfully";
            return RedirectToAction("Index");
        }

        // GET: /Cart/GetCartCount - for AJAX
        [HttpGet]
        public IActionResult GetCartCount()
        {
            return Json(new { count = _cartService.GetCartItemCount() });
        }
    }
}
