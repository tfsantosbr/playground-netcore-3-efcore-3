using Products.Domain.Categories;

namespace Products.Data.SqlServer.Seed
{
    public class ProductsSeed
    {
        public static Category[] Categories => new[]
        {
            new Category { Id = 1, Title = "Cell Phones" },
            new Category { Id = 2, Title = "TVs" },
            new Category { Id = 3, Title = "Notebooks" },
            new Category { Id = 4, Title = "Books" },
            new Category { Id = 5, Title = "Games" }
        };
    }
}