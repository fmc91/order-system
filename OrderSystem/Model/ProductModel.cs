using Common;
using System.Text.Json.Serialization;

namespace OrderSystem.Model
{
    public class ProductModel
    {
        public ProductModel(int productId, int categoryId, string name, ProductSize size, decimal price)
        {
            ProductId = productId;
            CategoryId = categoryId;
            Name = name;
            Size = size;
            Price = price;
        }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? CategoryName { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductSize Size { get; set; }

        public decimal Price { get; set; }
    }
}