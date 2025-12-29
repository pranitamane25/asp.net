using Microsoft.AspNetCore.Mvc;
using ShoppingCart.MVC.Repositories.Interfaces;

namespace ShoppingCart.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _cartRepo;
        private readonly IProductRepository _productRepo;

        public ShoppingCartController(
            IShoppingCartRepository cartRepo,
            IProductRepository productRepo)
        {
            _cartRepo = cartRepo;
            _productRepo = productRepo;
        }

        public IActionResult Index()
        {
            return View(_cartRepo.GetCartItems());
        }

        public IActionResult Add(int id)
        {
            var product = _productRepo.GetById(id);
            if (product != null)
                _cartRepo.AddToCart(product);

            return RedirectToAction("Index");
        }
    }
}
