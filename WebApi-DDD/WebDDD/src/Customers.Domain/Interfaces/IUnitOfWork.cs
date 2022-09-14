using System.Threading.Tasks;

namespace Customers.Domain.Interfaces
{
    public interface IUnitOfWork
    {
          Task Commit();
    }
}