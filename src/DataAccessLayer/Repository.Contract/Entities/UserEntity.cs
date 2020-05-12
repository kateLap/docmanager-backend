using Repository.Contract.Entities.Contract;
using System;
using System.Collections.Generic;

namespace Repository.Contract.Entities
{
    public class UserEntity: IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual WorkingPositionEntity WorkingPosition { get; set; }

        public virtual ICollection<DocumentEntity> DocumentsToReview { get; set; }

        public virtual ICollection<DocumentEntity> ApprovedDocuments { get; set; }
    }
}
