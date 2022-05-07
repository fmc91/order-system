using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class CategoryModel
    {
        public CategoryModel(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
