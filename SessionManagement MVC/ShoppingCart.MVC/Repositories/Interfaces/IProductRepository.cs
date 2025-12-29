using ShoppingCart.MVC.Models; // Assuming this is the correct namespace
using Newtonsoft.Json;
using ShoppingCart.MVC.Models;
using ShoppingCart.MVC.Repositories.Interfaces;

namespace ShoppingCart.MVC.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
    }
}
