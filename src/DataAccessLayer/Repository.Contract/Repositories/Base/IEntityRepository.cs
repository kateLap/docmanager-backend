using System;
using System.Threading.Tasks;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Repositories.Base
{
    public interface IEntityRepository<TEntity, in TId> : IRepository<TEntity>
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        Task<TEntity> GetByIdAsync(TId id);
    }
}
