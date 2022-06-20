using Domain.Base;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> dbSet;

        public Repository(EfContext efContext)
        {
            dbSet = efContext.Set<T>();
        }

        public async Task<T> AddEntity(T entity)
        {
            await dbSet.AddAsync(entity).ConfigureAwait(false);
            return entity;
        }

        public async Task<T> GetEntityById(object id)
        {
            return await dbSet.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.FirstOrDefaultAsync(expression);
        }

        public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).ToListAsync();
        }
    }
}
