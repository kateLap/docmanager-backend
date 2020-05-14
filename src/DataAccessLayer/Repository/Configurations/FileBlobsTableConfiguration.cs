using System;
using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class FileBlobsTableConfiguration : BaseTableConfiguration<FileBlobEntity, int>
    {
        public FileBlobsTableConfiguration() : base("FileBlobs")
        {
            Property(e => e.Content).IsOptional();
            Property(e => e.Details).IsOptional();
        }
    }
}
