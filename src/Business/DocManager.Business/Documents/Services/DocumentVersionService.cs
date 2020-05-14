using System;
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
        private readonly IFileBlobRepository _fileBlobRepository;

        public DocumentVersionService(
            IDocumentVersionRepository documentRepository, 
            IFileBlobRepository fileBlobRepository)
        {
            _documentVersionRepository = documentRepository;
            _fileBlobRepository = fileBlobRepository;
        }

        public async Task CreateDocumentVersion(DocumentVersion documentVersion, FileBlob fileBlob)
        {
            try
            {
                DocumentVersionEntity documentVersionEntity =
                    Mapper.Map<DocumentVersion, DocumentVersionEntity>(documentVersion);

                FileBlobEntity fileBlobEntity = Mapper.Map<FileBlob, FileBlobEntity>(fileBlob);

                FileBlobEntity resultFileBlob = _fileBlobRepository.Add(fileBlobEntity);

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
    }
}
