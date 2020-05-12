using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class DocumentVersionRepository : EntityRepository<DocumentVersionEntity, int>, IDocumentVersionRepository
    {
        public DocumentVersionRepository(DocManagerDbContext context) : base(context)
        {
        }
    }
}
