using AutoMapper;
using DocManager.Business.Contract.Enumerations.Models;
using DocManager.Business.Core.Extensions;
using Repository.Contract.Entities;

namespace DocManager.Business.Enumerations.Mappings
{
    public sealed class WorkingPositionProfile : Profile
    {
        public WorkingPositionProfile()
        {
            CreateMap<WorkingPositionEntity, WorkingPosition>();

            this.CreateMapFromId<int, WorkingPositionEntity>();

            CreateMap<WorkingPosition, WorkingPositionEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(e => e.Name))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
