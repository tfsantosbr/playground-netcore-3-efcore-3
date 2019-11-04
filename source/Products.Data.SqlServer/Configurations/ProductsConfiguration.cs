using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Products;

namespace Products.Data.SqlServer.Configurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            product.ToTable("Products").HasKey(p => p.Id);

            product.Property(p => p.Title).HasMaxLength(300);
            product.Property(p => p.Description).HasMaxLength(300);
            product.Property(p => p.Title).HasMaxLength(300);

            product.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}