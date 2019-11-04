using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Data.SqlServer.Seed;
using Products.Domain.Categories;

namespace Products.Data.SqlServer.Configurations
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.ToTable("Categories").HasKey(p => p.Id);

            category.Property(p => p.Title).HasMaxLength(300);

            category.HasData(ProductsSeed.Categories);
        }
    }
}