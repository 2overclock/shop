using Microsoft.EntityFrameworkCore;
using shop.web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.web.test.Database
{
    [TestClass]
    public class DatabaseTest
    {
        private readonly ApplicationDbContext _context;

        public DatabaseTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new ApplicationDbContext(options);

            databaseContext.Database.EnsureCreated();

            _context = databaseContext;
        }

        [TestMethod]
        public async Task Database_AddBrand()
        {
            var brandName = "Test Brand";
            var brand = new ProductBrand
            {
                Name = brandName
            };

            _context.ProductBrands.Add(brand);
            await _context.SaveChangesAsync();

            var added = _context.ProductBrands.Any(item => item.Name == brandName);

            Assert.IsTrue(added);
        }

        [TestMethod]
        public async Task Database_AddCategory()
        {
            var categoryName = "Test Category";
            var category = new ProductCategory
            {
                Name = categoryName
            };

            _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();

            var added = _context.ProductCategories.Any(item => item.Name == categoryName);

            Assert.IsTrue(added);
        }

        [TestMethod]
        public async Task Database_AddProduct()
        {
            var productName = "Test Product";

            var brands = _context.ProductBrands.ToList();
            var categories = _context.ProductCategories.ToList();

            var product = new Product
            {
                Name = productName,
                Brand = new ProductBrand 
                {
                    Name = "Test Brand" 
                },
                Category = new ProductCategory
                {
                    Name = "Test Category"
                },
                Gender = Gender.Male,
                AvailableSizes = new List<Sizes> { Sizes.Medium, Sizes.ExtraLarge },
                InsertDate = DateTime.Now
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var added = _context.Products.Any(item => item.Name == productName);

            Assert.IsTrue(added);
        }
    }
}
