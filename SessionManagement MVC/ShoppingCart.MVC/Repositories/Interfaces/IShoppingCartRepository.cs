using ShoppingCart.MVC.Models;

namespace ShoppingCart.MVC.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        List<CartItem> GetCartItems();
         void AddToCart(Product product);
    }
}
