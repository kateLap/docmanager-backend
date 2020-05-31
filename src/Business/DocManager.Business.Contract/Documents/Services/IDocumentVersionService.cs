using System.Collections.Generic;
using System.Threading.Tasks;
using DocManager.Business.Contract.Documents.Models;

namespace DocManager.Business.Contract.Documents.Services
{
    public interface IDocumentVersionService
    {
        Task CreateDocumentVersion(string userName, DocumentVersion documentVersion, FileBlob fileBlob);

        void DeleteDocumentVersion(DocumentVersion documentVersion);

        Task<DocumentVersion> GetDocumentVersion(int versionId);

        List<DocumentVersion> GetAll(int documentId);
    }
}
