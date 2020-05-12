using System;
using AutoMapper;
using Repository.Contract.Entities.Contract;

namespace DocManager.Business.Core.Extensions
{
    public static class AutoMapperProfileExtensions
    {
        public static void CreateMapFromId<TId, TResult>(this Profile self)
            where TId : struct, IEquatable<TId>
            where TResult : class, IEntity<TId>
        {
            self.CreateMap<TId, TResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(e => e));
        }
    }
}
