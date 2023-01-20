using shop.web.Data;

namespace shop.web.Services
{
    public interface IProductBrandService
    {
        Task<List<ProductBrand>> GetBrands();

        bool BrandsExists();

        Task<ProductBrand?> GetBrandById(int? id);

        Task<int> AddBrand(ProductBrand productBrand);

        Task<ProductBrand?> FindAsync(int? id);

        Task<int> UpdateBrand(ProductBrand productBrand);

        Task<int> DeleteBrand(int? id);

        bool ProductBrandExists(int id);
    }
}
