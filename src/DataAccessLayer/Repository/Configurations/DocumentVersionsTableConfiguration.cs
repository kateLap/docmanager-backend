using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class DocumentVersionsTableConfiguration : BaseTableConfiguration<DocumentVersionEntity, int>
    {
        public DocumentVersionsTableConfiguration() : base("DocumentVersions")
        {
            HasRequired(e => e.Document).WithMany(e => e.DocumentVersions);
            HasRequired(e => e.FileBlob).WithRequiredDependent(e => e.DocumentVersion);
        }
    }
}
