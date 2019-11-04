using System;
using System.Threading.Tasks;
using Products.Domain.Core.Pagination;
using Products.Domain.Products.Models;

namespace Products.Domain.Products.Repositories
{
    public interface IProductRepository
    {
         Task<IPagedList<ProductItem>> FindProducts(ProductParameters parameters);
         Task AddProduct(Product product);
         void UpdateProduct(Product product);
         Task<Product> GetProduct(Guid productId);
         void RemoveProduct(Product product);
    }
}