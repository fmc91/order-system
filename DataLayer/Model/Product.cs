using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Product
    {
        private Category? _category;

        public Product(int productId, int categoryId, string name, decimal price)
        {
            ProductId = productId;
            CategoryId = categoryId;
            Name = name;
            Price = price;
            StockItems = new HashSet<StockItem>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public double Weight { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

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
