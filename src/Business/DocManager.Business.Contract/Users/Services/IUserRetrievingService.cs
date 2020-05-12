using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocManager.Business.Contract.Users.Models;

namespace DocManager.Business.Contract.Users.Services
{
    public interface IUserRetrievingService
    {
        Task<ProfileUser> GetById(Guid id);

        Task<ProfileUser> GetByUserName(string userName);

        IEnumerable<ProfileUser> GetAll();
    }
}
