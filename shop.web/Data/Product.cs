namespace shop.web.Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }
        public ProductBrand Brand { get; set; }

        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public Gender Gender { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public List<Colors> AvailableColors { get; set; }

        public List<Sizes> AvailableSizes { get; set; }
    }
}
