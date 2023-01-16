using shop.web.Data;

namespace shop.web.Services
{
    public interface IProductService
    {
        Product? GetProduct(int id);

        List<Product> GetProducts();

        void AddProduct(Product product);
    }
}
