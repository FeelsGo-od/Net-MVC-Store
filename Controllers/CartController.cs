using Microsoft.AspNetCore.Mvc;
using RestSharpAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace RestSharpAPI.Controllers
{
    public class CartController : Controller
    {
        private readonly IMemoryCache _cache;

        public CartController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public IActionResult CartSummary()
        {
            if (!_cache.TryGetValue("CartItems", out List<CartItem>? cartItems))
            {
                // Cart items not found in cache, handle accordingly (e.g., show empty cart)
                cartItems = new List<CartItem>();
            }

            return View(cartItems);
        }

        public IActionResult AddToCart(decimal variantId, string name, decimal retailPrice, int quantity = 1)
        {
            var newItem = new CartItem
            {
                VariantId = variantId,
                Name = name,
                RetailPrice = retailPrice,
                Quantity = quantity
            };

            if (!_cache.TryGetValue("CartItems", out List<CartItem>? cartItems))
            {
                cartItems = new List<CartItem>();
            }

            // Check if the item already exists in the cart
            var existingItem = cartItems?.FirstOrDefault(i => i.VariantId == newItem.VariantId);
            if (existingItem != null)
            {
                // Update quantity if the item already exists
                existingItem.Quantity += newItem.Quantity;
            }
            else
            {
                // Add new item if it doesn't exist
                cartItems?.Add(newItem);
            }

            // Store the updated cart items in cache
            _cache.Set("CartItems", cartItems);

            return RedirectToAction(nameof(CartSummary));
        }

        public IActionResult RemoveFromCart(int productId)
        {
            if (_cache.TryGetValue("CartItems", out List<CartItem>? cartItems))
            {
                cartItems?.RemoveAll(i => i.VariantId == productId);
                _cache.Set("CartItems", cartItems);
            }

            return RedirectToAction(nameof(CartSummary));
        }

        public IActionResult ClearCart()
        {
            _cache.Remove("CartItems");
            return RedirectToAction(nameof(CartSummary));
        }
    }
}
