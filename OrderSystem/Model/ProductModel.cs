using System.Text.Json.Serialization;
using DataLayer;

namespace OrderSystem.Model
{
    public class ProductModel
    {
        public ProductModel(int productId, int categoryId, string name, decimal price)
        {
            ProductId = productId;
            CategoryId = categoryId;
            Name = name;
            Price = price;
        }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? CategoryName { get; set; }

        public decimal Price { get; set; }

        public Size Size { get; set; }

        public double Weight { get; set; }
    }
}