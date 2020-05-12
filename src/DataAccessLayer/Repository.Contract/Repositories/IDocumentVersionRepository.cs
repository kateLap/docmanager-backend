using Repository.Contract.Entities;
using Repository.Contract.Repositories.Base;

namespace Repository.Contract.Repositories
{
    public interface IDocumentVersionRepository : IEntityRepository<DocumentVersionEntity, int>
    {
    }
}
