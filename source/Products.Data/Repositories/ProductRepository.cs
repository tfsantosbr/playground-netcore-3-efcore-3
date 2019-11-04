using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products.Data.SqlServer.Context;
using Products.Domain.Core.Pagination;
using Products.Domain.Products;
using Products.Domain.Products.Models;
using Products.Domain.Products.Repositories;

namespace Products.Data.SqlServer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbSet<Product> _products;

        public ProductRepository(ProductsContext context)
        {
            _products = context.Products;
        }

        public async Task AddProduct(Product product)
        {
            await _products.AddAsync(product);
        }

        public async Task<IPagedList<ProductItem>> FindProducts(ProductParameters parameters)
        {
            var query = _products
                .Include(p => p.Category)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.Query))
            {
                query = query.Where(p => p.Title.Contains(parameters.Query));
            }

            query = query.OrderBy(p => p.Title);

            var source = query.Select(p => new ProductItem
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                Category = p.Category.Title,
            });

            var count = await source.CountAsync();
            var items = await source.Skip((parameters.Page - 1) * parameters.PageSize).Take(parameters.PageSize).ToListAsync();

            return new PagedList<ProductItem>(items, count, parameters.Page, parameters.PageSize);
        }

        public async Task<Product> GetProduct(Guid productId)
        {
            return await _products.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public void UpdateProduct(Product product)
        {
            _products.Update(product);
        }
        
        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }

    }
}