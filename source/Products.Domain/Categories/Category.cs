using System.Collections.Generic;
using Products.Domain.Products;

namespace Products.Domain.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}