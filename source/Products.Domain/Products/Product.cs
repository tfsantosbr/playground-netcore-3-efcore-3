using System;
using Products.Domain.Categories;

namespace Products.Domain.Products
{
    public class Product
    {
        public Product(string title, string description, decimal price, int categoryId)
        {
            Title = title;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }

        public Category Category { get; private set; }

        public void Update(string title, string description, decimal price, int categoryId)
        {
            Title = title;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
    }
}