using System.Collections.Generic;
using DocManager.Business.Contract.Enumerations.Models;
using DocManager.Business.Contract.Users.Models;

namespace DocManager.Business.Contract.Documents.Models
{
    public class Document
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public List<ProfileUser> Reviewers { get; set; }

        public List<DocumentVersion> DocumentVersions { get; set; }

        public List<WorkingPosition> ModifyPositions { get; set; }

        public List<ProfileUser> UsersWithApprove { get; set; }
    }
}
