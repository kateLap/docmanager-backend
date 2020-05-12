using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Repository.Contexts;
using Repository.Contract.Entities.Contract;
using Repository.Contract.Repositories.Base;

namespace Repository.Repositories.Base
{
    public class EntityRepository<TEntity, TId> : Repository<TEntity>, IEntityRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        public EntityRepository(DocManagerDbContext context) : base(context)
        {
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await GetAll().Where(entity => entity.Id.Equals(id)).SingleOrDefaultAsync();
        }
    }
}
