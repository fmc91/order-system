using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Category
    {
        public Category(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; }
    }
}
