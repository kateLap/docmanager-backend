using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class WorkingPositionRepository : EntityRepository<WorkingPositionEntity, int>, IWorkingPositionRepository
    {
        public WorkingPositionRepository(DocManagerDbContext context) : base(context)
        {
        }
    }
}
