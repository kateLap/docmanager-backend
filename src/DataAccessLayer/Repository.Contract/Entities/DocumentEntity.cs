using System.Collections.Generic;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class DocumentEntity : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual StatusEntity Status { get; set; }

        public virtual ICollection<UserEntity> Reviewers { get; set; }

        public virtual ICollection<DocumentVersionEntity> DocumentVersions { get; set; }

        public virtual ICollection<WorkingPositionEntity> ModifyPositions { get; set; }

        public virtual ICollection<UserEntity> UsersWithApprove { get; set; }

    }
}
