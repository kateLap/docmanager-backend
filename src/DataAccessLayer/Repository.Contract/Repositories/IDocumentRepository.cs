using Repository.Contract.Entities;
using Repository.Contract.Repositories.Base;

namespace Repository.Contract.Repositories
{
    public interface IDocumentRepository : IEntityRepository<DocumentEntity, int>
    {
    }
}
