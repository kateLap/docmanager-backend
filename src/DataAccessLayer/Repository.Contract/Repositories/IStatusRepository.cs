using Repository.Contract.Entities;
using Repository.Contract.Repositories.Base;

namespace Repository.Contract.Repositories
{
    public interface IStatusRepository : IEntityRepository<StatusEntity, int>
    {
    }
}
