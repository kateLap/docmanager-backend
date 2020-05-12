using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Contract.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);

        Task<int> CountAsync();

        Task CommitAsync();
    }
}
