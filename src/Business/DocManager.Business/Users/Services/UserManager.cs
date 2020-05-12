using System;
using DocManager.Business.Contract.Users.Models;
using Microsoft.AspNet.Identity;

namespace DocManager.Business.Users.Services
{
    public class UserManager : UserManager<ProfileUser, Guid>
    {
        public UserManager(IUserStore<ProfileUser, Guid> store) : base(store)
        {
            PasswordValidator = new PasswordValidator()
            {
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonLetterOrDigit = true,
                RequiredLength = 7
            };
        }
    }
}
