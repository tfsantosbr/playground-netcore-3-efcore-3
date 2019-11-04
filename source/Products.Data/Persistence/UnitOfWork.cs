using System.Threading.Tasks;
using Products.Data.SqlServer.Context;
using Products.Domain.Core.Persistence;

namespace Products.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductsContext _productsContext;

        public UnitOfWork(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }

        public async Task Commit()
        {
            await _productsContext.SaveChangesAsync();
        }
    }
}