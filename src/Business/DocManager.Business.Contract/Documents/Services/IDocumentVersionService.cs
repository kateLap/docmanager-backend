using System.Threading.Tasks;
using DocManager.Business.Contract.Documents.Models;

namespace DocManager.Business.Contract.Documents.Services
{
    public interface IDocumentVersionService
    {
        Task CreateDocumentVersion(DocumentVersion document, FileBlob fileBlob);
    }
}
