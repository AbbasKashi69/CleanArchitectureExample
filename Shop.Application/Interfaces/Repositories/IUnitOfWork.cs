
using Shop.Domain.Common;

namespace Shop.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;

        Task<int> Save(CancellationToken cancellationToken);
        Task Rollback();
    }
}
