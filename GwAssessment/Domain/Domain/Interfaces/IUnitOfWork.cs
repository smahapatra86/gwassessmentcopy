using Domain.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IRepository<T> AsyncRepository<T>() where T : BaseEntity;
    }
}
