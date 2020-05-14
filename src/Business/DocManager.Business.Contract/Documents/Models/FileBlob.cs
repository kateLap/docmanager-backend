namespace DocManager.Business.Contract.Documents.Models
{
    public class FileBlob
    {
        public int Id { get; set; }

        public string Details { get; set; }

        public byte[] Content { get; set; }
    }
}
