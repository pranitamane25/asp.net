using Shopping.MVC.Models;
using Shopping.MVC.Repositories.Interfaces;

namespace Shopping.MVC.Repositories.Implementations;

//Provider

public class ShoppingCartRepository : IShoppingCartRepository
{    
    private  List<Item> items = new List<Item>();
    public List<Item> GetItems()
    {
        return items;
    }

    public void AddToCart(int productId)
    {
        
         
    }

    public void RemoveFromCart(int productId)
    {
      
    }
}
