using System.Collections.Generic;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class FileBlobEntity : IEntity<int>
    {
        public int Id { get; set; }

        public string Details { get; set; }

        public byte[] Content { get; set; }

        public virtual ICollection<DocumentVersionEntity> DocumentVersion { get; set; }
    }
}
