using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class DocumentRepository : EntityRepository<DocumentEntity, int>, IDocumentRepository
    {
        public DocumentRepository(DocManagerDbContext context) : base(context)
        {
        }
    }
}
