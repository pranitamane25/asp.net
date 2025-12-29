
using Shopping.MVC.Models;

namespace Shopping.MVC.Repositories.Interfaces;


//Connector (Contract) (Agreement)
public interface  IProductsRepository
{
    List<Product> GetAllProducts();
   
    void Insert(Product theProduct);
    void Remove(Product theProduct);

}
