using System.Threading.Tasks;

namespace Products.Domain.Core.Persistence
{
    public interface IUnitOfWork
    {
         Task Commit();
    }
}