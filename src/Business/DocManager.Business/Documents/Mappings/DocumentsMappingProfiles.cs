using System;
using AutoMapper;
using DocManager.Business.Contract.Documents.Models;
using DocManager.Business.Core.Extensions;
using Repository.Contract.Entities;

namespace DocManager.Business.Documents.Mappings
{
    class DocumentsMappingProfiles : Profile
    {
        public DocumentsMappingProfiles()
        {
            CreateMap<DocumentVersionEntity, DocumentVersion>();
            CreateMap<DocumentVersion, DocumentVersionEntity>();
            this.CreateMapFromId<int, DocumentVersionEntity>();

            CreateMap<DocumentEntity, Document>();
            CreateMap<Document, DocumentEntity>();
            this.CreateMapFromId<int, DocumentEntity>();

            CreateMap<FileBlob, FileBlobEntity>()
                .ForMember(dest => dest.DocumentVersion, 
                    opt => opt.Ignore());
            CreateMap<FileBlobEntity, FileBlob>();
        }
    }
}
