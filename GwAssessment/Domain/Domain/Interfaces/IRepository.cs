using Domain.Base;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> AddEntity(T entity);

        Task<T> GetEntityById(object id);

        Task<T> GetEntityAsync(Expression<Func<T, bool>> expression);
    }
}
