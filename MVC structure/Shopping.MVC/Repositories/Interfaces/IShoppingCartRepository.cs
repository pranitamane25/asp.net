using Shopping.MVC.Models;


namespace Shopping.MVC.Repositories.Interfaces;

public interface IShoppingCartRepository
{

    List<Item> GetItems();
    void AddToCart(int productId);
    void RemoveFromCart(int productId);
}
