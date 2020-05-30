using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocManager.Business.Contract.Core.Exceptions;
using DocManager.Business.Contract.Documents.Models;
using DocManager.Business.Contract.Documents.Services;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;

namespace DocManager.Business.Documents.Services
{
    public class DocumentVersionService : IDocumentVersionService
    {
        private readonly IDocumentVersionRepository _documentVersionRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IFileBlobRepository _fileBlobRepository;

        public DocumentVersionService(
            IDocumentVersionRepository documentVersionRepository,
            IDocumentRepository documentRepository,
            IFileBlobRepository fileBlobRepository)
        {
            _documentRepository = documentRepository;
            _documentVersionRepository = documentVersionRepository;
            _fileBlobRepository = fileBlobRepository;
        }

        public async Task CreateDocumentVersion(string userName, DocumentVersion documentVersion, FileBlob fileBlob)
        {
            try
            {
                DocumentEntity documentEntity = _documentRepository
                    .Get(e => e.Id == documentVersion.Document.Id)
                    .FirstOrDefault(e => e.Reviewers.Any(u => u.UserName == userName));

                if (documentEntity == null)
                {
                    throw new DocManagerException("Requested document does not exist or not accessible.");
                }

                //DocumentEntity document = _documentRepository
                //    .Get(e => e.Id == documentVersion.Document.Id)
                //    .FirstOrDefault();

                //if (document?.Status.Name != "Approved")
                //{
                //    throw new DocManagerException("You cannot add new version for document in review status.");
                //}

                DocumentVersionEntity documentVersionEntity =
                    Mapper.Map<DocumentVersion, DocumentVersionEntity>(documentVersion);

                FileBlobEntity fileBlobEntity = Mapper.Map<FileBlob, FileBlobEntity>(fileBlob);

                _fileBlobRepository.Add(fileBlobEntity);

                documentVersionEntity.FileBlob = fileBlobEntity;

                _documentVersionRepository.Add(documentVersionEntity);


                await _documentVersionRepository.CommitAsync();
            }
            catch (Exception e)
            {
                throw new DocManagerException(
                    "Error during document version creation.", 
                    e.Message, e);
            }
        }

        public void DeleteDocumentVersion(DocumentVersion documentVersion)
        {
            _documentVersionRepository.Delete(Mapper.Map<DocumentVersionEntity>(documentVersion));
        }

        public DocumentVersion GetDocumentVersion(int versionId)
        {
            var entity = _documentVersionRepository.GetByIdAsync(versionId);

            return Mapper.Map<DocumentVersion>(entity);
        }

        public List<DocumentVersion> GetAll(int documentId)
        {
            var documentVersions = _documentVersionRepository.GetAll()
                .Where(e => e.Document.Id == documentId)
                .Select(e => Mapper.Map<DocumentVersion>(e));

            return documentVersions.ToList();
        }
    }
}
