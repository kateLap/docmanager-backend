using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class DocumentsTableConfiguration : BaseTableConfiguration<DocumentEntity, int>
    {
        public DocumentsTableConfiguration() : base("Documents")
        {
            Property(e => e.Name).IsRequired();
            HasRequired(e => e.Status)
                .WithMany(p => p.Documents);

            HasMany(e => e.ModifyPositions)
                .WithMany(e => e.DocumentsToModify)
                .Map(e =>
                {
                    e.MapLeftKey("Document_Id");
                    e.MapRightKey("WorkingPosition_Id");
                    e.ToTable("DocumentsModifyPositions");
                });

            HasMany(e => e.Reviewers)
                .WithMany(e => e.DocumentsToReview)
                .Map(e =>
                {
                    e.MapLeftKey("Document_Id");
                    e.MapRightKey("User_Id");
                    e.ToTable("DocumentsReviewers");
                });

            HasMany(e => e.UsersWithApprove)
                .WithMany(e => e.ApprovedDocuments)
                .Map(e =>
            {
                e.MapLeftKey("Document_Id");
                e.MapRightKey("User_Id");
                e.ToTable("DocumentsUsersWithApprove");
            });
        }
    }
}
