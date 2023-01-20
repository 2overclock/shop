using Microsoft.EntityFrameworkCore;
using shop.web.Data;

namespace shop.web.Services
{
    public class ProductBrandService : IProductBrandService
    {
        private readonly ApplicationDbContext _context;

        public ProductBrandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddBrand(ProductBrand productBrand)
        {
            _context.Add(productBrand);

            return await _context.SaveChangesAsync();
        }

        public bool BrandsExists()
        {
            return _context.ProductBrands != null;
        }

        public async Task<int> DeleteBrand(int? id)
        {
            var productBrand = await FindAsync(id);
            if (productBrand != null)
                _context.ProductBrands.Remove(productBrand);

            return await _context.SaveChangesAsync();
        }

        public async Task<ProductBrand?> FindAsync(int? id)
        {
            return await _context.ProductBrands.FindAsync(id);
        }

        public async Task<ProductBrand?> GetBrandById(int? id)
        {
            if(id == null) 
                return null;

            return await _context.ProductBrands
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<ProductBrand>> GetBrands()
        {
            return _context.ProductBrands != null 
                ? await _context.ProductBrands.ToListAsync() 
                : throw new Exception("Entity set 'ApplicationDbContext.ProductBrands' is null.");
        }

        public async Task<int> UpdateBrand(ProductBrand productBrand)
        {
            _context.Update(productBrand);

            return await _context.SaveChangesAsync();
        }

        public bool ProductBrandExists(int id)
        {
            return (_context.ProductBrands?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
