using System;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class FileBlobEntity: IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Length { get; set; }

        public byte[] Content { get; set; }

        public virtual DocumentVersionEntity DocumentVersion { get; set; }
    }
}
