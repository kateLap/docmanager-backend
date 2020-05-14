using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class DocumentVersionsTableConfiguration : BaseTableConfiguration<DocumentVersionEntity, int>
    {
        public DocumentVersionsTableConfiguration() : base("DocumentVersions")
        {
            Property(e => e.Name).IsOptional();
            HasRequired(e => e.Document).WithMany(e => e.DocumentVersions);
            HasRequired(e => e.FileBlob).WithMany(e => e.DocumentVersion);
        }
    }
}
