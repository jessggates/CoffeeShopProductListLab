using CoffeeShopProductList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeShopProductList.DAL;

namespace CoffeeShopProductList.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductRepository _productRepository;
        private readonly AhbcTeachingContext _context;

        public ProductController(AhbcTeachingContext context)
        {
            _context = context;
            _productRepository = new ProductRepository(_context);
        }

        public IActionResult Index()
        {;
            return View(_productRepository.GetAllProducts());
        }

        public IActionResult Detail(int id)
        {
            ProductViewModel product = _productRepository.GetProductById(id);
            return View(product);
        }
    }
}
