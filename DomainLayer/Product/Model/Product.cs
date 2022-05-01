using Common;

namespace DomainLayer.ProductModel
{
    public class Product
    {
        public Product(int productId, Category category, string name, ProductSize size, decimal price)
        {
            ProductId = productId;
            Category = category;
            Name = name;
            Size = size;
            Price = price;
        }

        public int ProductId { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public ProductSize Size { get; set; }

        public decimal Price { get; set; }
    }
}