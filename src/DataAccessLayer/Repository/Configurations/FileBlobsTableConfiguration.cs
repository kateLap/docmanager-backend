using System;
using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class FileBlobsTableConfiguration : BaseTableConfiguration<FileBlobEntity, Guid>
    {
        public FileBlobsTableConfiguration() : base("FileBlobs")
        {
            Property(e => e.Name).IsRequired();
            Property(e => e.Content).IsRequired();
            Property(e => e.Length).IsOptional();
        }
    }
}
