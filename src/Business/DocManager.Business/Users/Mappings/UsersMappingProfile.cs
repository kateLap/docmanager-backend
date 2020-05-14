using System;
using AutoMapper;
using DocManager.Business.Contract.Users.Models;
using DocManager.Business.Core.Extensions;
using Repository.Contract.Entities;

namespace DocManager.Business.Users.Mappings
{
    public sealed class UsersMappingProfile : Profile
    {

        public UsersMappingProfile()
        {
            CreateMap<UserEntity, ProfileUser>();
            this.CreateMapFromId<Guid, UserEntity>();

            CreateMap<ProfileUser, UserEntity>()
                .ForMember(dest => dest.ApprovedDocuments, opt => opt.Ignore())
                .ForMember(dest => dest.DocumentsToReview, opt => opt.Ignore());
        }
    }
}
