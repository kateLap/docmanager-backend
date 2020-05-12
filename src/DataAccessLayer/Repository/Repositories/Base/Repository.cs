using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Repository.Contexts;

namespace Repository.Repositories.Base
{
    public class Repository<TEntity> : AbstractRepository<TEntity> where TEntity : class
    {
        private readonly DocManagerDbContext _context;

        public Repository(DocManagerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException($"{nameof(context)} is null");
        }

        protected DbSet<TEntity> Entities => _context.Set<TEntity>();

        public override IQueryable<TEntity> GetAll()
        {
            return Entities;
        }

        public override TEntity Add(TEntity entity)
        {
            return Attach(entity, EntityState.Added);
        }

        public override TEntity Update(TEntity entity)
        {
            return Attach(entity, EntityState.Modified);
        }

        public override TEntity Delete(TEntity entity)
        {
            return Attach(entity, EntityState.Deleted);
        }

        public override IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            return Entities.AddRange(entities);
        }

        public override async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected TEntity Attach(TEntity entity, EntityState state)
        {
            Entities.Attach(entity);
            _context.Entry(entity).State = state;

            return entity;
        }
    }
}
