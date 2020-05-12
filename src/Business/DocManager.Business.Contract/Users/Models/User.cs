using System;
using DocManager.Business.Contract.Enumerations.Models;
using Microsoft.AspNet.Identity;

namespace DocManager.Business.Contract.Users.Models
{
    public class ProfileUser : IUser<Guid>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual WorkingPosition WorkingPosition { get; set; }
    }
}
