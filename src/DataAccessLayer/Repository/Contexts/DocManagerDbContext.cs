using System.Data.Entity;
using Repository.Contract.Entities;

namespace Repository.Contexts
{
    public class DocManagerDbContext : DbContext
    {
        #region Tables

        public DbSet<DocumentEntity> Documents { get; set; }

        public DbSet<DocumentVersionEntity> DocumentVersions { get; set; }

        public DbSet<FileBlobEntity> FileBlobs { get; set; }

        public DbSet<StatusEntity> Statuses { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<WorkingPositionEntity> WorkingPositions { get; set; }

        #endregion

        public DocManagerDbContext() : base("DocManagerDb")
        {
                /*Database.SetInitializer(
                    new MigrateDatabaseToLatestVersion<DocManagerDbContext, Migrations.Configuration>(true));*/
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var assembly = this.GetType().Assembly;

            modelBuilder.Configurations.AddFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
