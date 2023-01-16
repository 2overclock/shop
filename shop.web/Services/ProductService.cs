using Microsoft.EntityFrameworkCore;
using shop.web.Data;

namespace shop.web.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Add(product);

            _context.SaveChangesAsync();
        }

        public Product? GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            var applicationDbContext = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category);

            return applicationDbContext.ToList();
        }
    }
}
