using AutoMapper;
using DocManager.Business.Contract.Enumerations.Models;
using DocManager.Business.Core.Extensions;
using Repository.Contract.Entities;

namespace DocManager.Business.Enumerations.Mappings
{
    public class StatusMappingProfile : Profile
    {
        public StatusMappingProfile()
        {
            CreateMap<StatusEntity, Status>();
            this.CreateMapFromId<int, StatusEntity>();
            CreateMap<Status, StatusEntity>()
                .ForMember(dest => dest.Documents, opt => opt.Ignore());

        }
    }
}
