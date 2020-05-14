using System.Collections.Generic;
using DocManager.Business.Contract.Enumerations.Models;
using DocManager.Business.Contract.Users.Models;

namespace DocManager.Web.Models
{
    public class DocumentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public List<ProfileModel> Reviewers { get; set; }

        public List<WorkingPosition> ModifyPositions { get; set; }
    }
}