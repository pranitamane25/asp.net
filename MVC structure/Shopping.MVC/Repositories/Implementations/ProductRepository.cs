using Shopping.MVC.Models;
using Shopping.MVC.Repositories.Interfaces;

namespace Shopping.MVC.Repositories.Implementations;
public class ProductRepository : IProductsRepository
{
    List<Product> products=new List<Product>();

      public ProductRepository()
    {
        products.Add(new Product { Id = 1, Name = "Laptop", Price = 50000 });
        products.Add(new Product { Id = 2, Name = "Mobile", Price = 20000 });
        products.Add(new Product { Id = 3, Name = "Headphones", Price = 3000 });
        products.Add(new Product{Id=4,Name="earbuds",Price=2000});
        products.Add(new Product{Id=5,Name="pen",Price=10});
    }

    public List<Product> GetAllProducts()
    {
        return products;
    }

    public void Insert(Product theProduct)
    {
     
        products.Add(theProduct);
       
    }

    public void Remove(Product theProduct)
    {
        Console.WriteLine($"Product:,{theProduct.Id} {theProduct.Name}, {theProduct.Price}");
        products.Remove(theProduct);
       
    }
}
