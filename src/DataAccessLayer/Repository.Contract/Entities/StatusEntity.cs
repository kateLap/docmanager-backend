using System.Collections.Generic;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class StatusEntity : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DocumentEntity> Documents { get; set; }
    }
}
