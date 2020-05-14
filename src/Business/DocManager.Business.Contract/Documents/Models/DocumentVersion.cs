namespace DocManager.Business.Contract.Documents.Models
{
    public class DocumentVersion
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public FileBlob FileBlob { get; set; }

        public Document Document { get; set; }
    }
}
