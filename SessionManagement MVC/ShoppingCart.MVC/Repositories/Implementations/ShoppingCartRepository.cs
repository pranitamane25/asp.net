using ShoppingCart.MVC.Models;
using ShoppingCart.MVC.Repositories.Interfaces;

namespace ShoppingCart.MVC.Repositories.Implementations
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private static List<CartItem> _cart = new();

        public List<CartItem> GetCartItems()
        {
            return _cart;
        }

        public void AddToCart(Product product)
        {
            var item = _cart.FirstOrDefault(x => x.ProductId == product.Id);

            if (item == null)
            {
                _cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }
        }
    }
}
