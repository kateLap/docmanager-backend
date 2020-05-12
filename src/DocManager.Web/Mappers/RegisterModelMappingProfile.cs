using AutoMapper;
using DocManager.Business.Contract.Users.Models;
using DocManager.Web.Models;

namespace DocManager.Web.Mappers
{
    public class RegisterModelMappingProfile : Profile
    {
        public RegisterModelMappingProfile()
        {
            CreateMap<RegisterModel, ProfileUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ProfileUser, ProfileModel>()
                .ForMember(dest => dest.IsSelf, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}