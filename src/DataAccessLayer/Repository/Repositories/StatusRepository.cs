using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class StatusRepository : EntityRepository<StatusEntity, int>, IStatusRepository
    {
        public StatusRepository(DocManagerDbContext context) : base(context)
        {
        }
    }
}
