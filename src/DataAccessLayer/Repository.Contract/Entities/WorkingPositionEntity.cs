using System.Collections.Generic;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class WorkingPositionEntity : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }

        public virtual ICollection<DocumentEntity> DocumentsToModify { get; set;  }
    }
}
