using Microsoft.AspNetCore.Mvc;
using ShoppingCart.MVC.Repositories.Interfaces;

namespace ShoppingCart.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var products = _repository.GetAll();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _repository.GetById(id);
            return View(product);
        }
    }
}
