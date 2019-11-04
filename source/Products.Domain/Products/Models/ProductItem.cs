using System;

namespace Products.Domain.Products.Models
{
    public class ProductItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}