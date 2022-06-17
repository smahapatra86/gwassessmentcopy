using Domain.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> AddEntity(T entity);

        Task<T> GetEntityById(object id);
    }
}
