using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocManager.Business.Contract.Core.Exceptions;
using DocManager.Business.Contract.Documents.Models;
using DocManager.Business.Contract.Documents.Services;
using DocManager.Business.Contract.Enumerations.Models;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;

namespace DocManager.Business.Documents.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IStatusRepository _statusRepository;

        public DocumentService(IDocumentRepository documentRepository, IStatusRepository statusRepository)
        {
            _documentRepository = documentRepository;
            _statusRepository = statusRepository;
        }

        public async Task CreateDocument(Document document)
        {
            try
            {
                StatusEntity statusEntity = _statusRepository
                    .GetAll()
                    .AsNoTracking()
                    .FirstOrDefault(s => s.Name == "Approved");

                document.Status = Mapper.Map<StatusEntity, Status>(statusEntity);

                DocumentEntity documentEntity = Mapper.Map<Document, DocumentEntity>(document);

                documentEntity.UsersWithApprove = documentEntity.Reviewers;

                _documentRepository.Add(documentEntity);

                await _documentRepository.CommitAsync();
            }
            catch (Exception e)
            {
                throw new DocManagerException("Error during document creation", e.Message, e);
            }
        }

        public List<Document> GetAll(string selfUserName)
        {
            List<DocumentEntity> documentEntities = _documentRepository
                .GetAll()
                .Where(e => e.Reviewers.Any(u => u.UserName == selfUserName))
                .ToList();

            return documentEntities.Select(Mapper.Map<DocumentEntity, Document>).ToList();
        }

        public Document GetDocument(string selfUserName, int documentId)
        {
            DocumentEntity documentEntity = _documentRepository
                .Get(e => e.Id == documentId)
                .FirstOrDefault(e => e.Reviewers.Any(u => u.UserName == selfUserName));

            if (documentEntity == null)
            {
                throw new DocManagerException("Requested document does not exist or not accessible.");
            }

            return Mapper.Map<Document>(documentEntity);
        }

        public void Approve(string selfUserName, int documentId)
        {
            throw new NotImplementedException();
        }

        public void Decline(string selfUserName, int documentId)
        {
            throw new NotImplementedException();
        }
    }
}
