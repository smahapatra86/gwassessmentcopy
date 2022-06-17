using Domain.Base;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfContext dbContext;

        public UnitOfWork(EfContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
