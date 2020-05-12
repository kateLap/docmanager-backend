using System;
using DocManager.Business.Contract.Enumerations.Models;

namespace DocManager.Web.Models
{
    public class ProfileModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public WorkingPosition WorkingPosition { get; set; }

        public bool IsSelf { get; set; }
    }
}