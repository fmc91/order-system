using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Product
    {
        private Category? _category;

        public Product(int productId, int categoryId, string name, ProductSize size, decimal price)
        {
            ProductId = productId;
            CategoryId = categoryId;
            Name = name;
            Size = size;
            Price = price;
            StockItems = new HashSet<StockItem>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public ProductSize Size { get; set; }

        public decimal Price { get; set; }

        public virtual Category Category
        {
            get => _category ??
                throw new InvalidOperationException($"Uninitialized property: {nameof(Category)}");
            set => _category = value;
        }

        public virtual ICollection<StockItem> StockItems { get; }

        public virtual ICollection<OrderItem> OrderItems { get; }
    }
}
