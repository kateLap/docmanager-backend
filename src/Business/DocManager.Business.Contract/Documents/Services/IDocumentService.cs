using System.Collections.Generic;
using System.Threading.Tasks;
using DocManager.Business.Contract.Documents.Models;

namespace DocManager.Business.Contract.Documents.Services
{
    public interface IDocumentService
    {
        Task CreateDocument(Document document);

        List<Document> GetAll(string selfUserName);

        Document GetDocument(string selfUserName, int documentId);

        void Approve(string selfUserName, int documentId);

        void Decline(string selfUserName, int documentId);
    }
}
