using System;

namespace DocManager.Business.Contract.Documents.Models
{
    public class FileBlob
    {
        public Guid Id { get; set; }

        public int Details { get; set; }

        public byte[] Content { get; set; }
    }
}
