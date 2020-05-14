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
                .ForMember(dest => dest.DocumentsToModify, opt => opt.Ignore())
                .ForMember(dest => dest.Users, opt => opt.Ignore());
        }
    }
}
