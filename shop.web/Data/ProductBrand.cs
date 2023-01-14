using Microsoft.Extensions.Hosting;

namespace shop.web.Data
{
    public class ProductBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
