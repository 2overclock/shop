using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace shop.web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property(e => e.AvailableColors)
                .HasConversion(
                    v => string.Join(",", v.Select(item => (int)item)),
                    v => v.Split(',', StringSplitOptions.None).Select(item => (Colors)Enum.Parse(typeof(Colors), item)).ToList()
                );

            builder.Entity<Product>()
                .Property(e => e.AvailableSizes)
                .HasConversion(
                    v => string.Join(",", v.Select(item => (int)item)),
                    v => v.Split(',', StringSplitOptions.None).Select(item => (Sizes)Enum.Parse(typeof(Sizes), item)).ToList()
                );

            base.OnModelCreating(builder);
        }
    }
}