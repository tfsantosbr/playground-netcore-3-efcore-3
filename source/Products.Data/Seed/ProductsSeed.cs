using Products.Domain.Categories;

namespace Products.Data.SqlServer.Seed
{
    public class ProductsSeed
    {
        public static Category[] Categories => new[]
        {
            new Category { Id = 1, Title = "Cell Phones" },
            new Category { Id = 2, Title = "TVs" },
            new Category { Id = 4, Title = "Books" },
            new Category { Id = 6, Title = "Audio" },
            new Category { Id = 7, Title = "Video" },
            new Category { Id = 8, Title = "Kids" },
        };
    }
}