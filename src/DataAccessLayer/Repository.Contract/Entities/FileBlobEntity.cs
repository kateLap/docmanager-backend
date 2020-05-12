using System;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class FileBlobEntity: IEntity<Guid>
    {
        public Guid Id { get; set; }

        public int Details { get; set; }

        public byte[] Content { get; set; }

        public virtual DocumentVersionEntity DocumentVersion { get; set; }
    }
}
