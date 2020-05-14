using AutoMapper;
using DocManager.Business.Contract.Documents.Models;
using DocManager.Web.Models;

namespace DocManager.Web.Mappers
{
    public class DocumentMappingProfile : Profile
    {
        public DocumentMappingProfile()
        {
            CreateMap<DocumentModel, Document>()
                .ForMember(dest => dest.UsersWithApprove, opt => opt.Ignore())
                .ForMember(dest => dest.DocumentVersions, opt => opt.Ignore());
            CreateMap<Document, DocumentModel>();

            CreateMap<DocumentVersion, DocumentVersionModel>();
        }
    }
}