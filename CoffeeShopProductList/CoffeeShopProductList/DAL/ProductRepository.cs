using CoffeeShopProductList.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopProductList.DAL
{
    public class ProductRepository
    {
        private readonly AhbcTeachingContext _context;

        public ProductRepository(AhbcTeachingContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            return _context.Products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category
            })
           .ToList();
        }

        public ProductViewModel GetProductById(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public void AddProduct(ProductViewModel product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(ProductViewModel product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }
    }
}
