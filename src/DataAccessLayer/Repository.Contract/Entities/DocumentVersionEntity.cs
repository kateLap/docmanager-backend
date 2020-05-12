using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
   public class DocumentVersionEntity : IEntity<int>
    {
        public int Id { get; set; }

        public virtual FileBlobEntity FileBlob { get; set; }

        public virtual DocumentEntity Document { get; set; }
    }
}
