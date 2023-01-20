using shop.web.Data;

namespace shop.web.Services
{
    public interface IProductService
    {
        Product? GetProduct(int id);

        List<Product> GetProducts();

        Task<int> AddProduct(Product product);
    }
}
