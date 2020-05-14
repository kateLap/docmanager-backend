namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFileBlobsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DocumentVersions", "FileBlob_Id", "dbo.FileBlobs");
            DropIndex("dbo.DocumentVersions", new[] { "FileBlob_Id" });
            DropColumn("dbo.DocumentVersions", "FileBlob_Id");
            DropTable("dbo.FileBlobs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FileBlobs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Details = c.String(),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DocumentVersions", "FileBlob_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.DocumentVersions", "FileBlob_Id");
            AddForeignKey("dbo.DocumentVersions", "FileBlob_Id", "dbo.FileBlobs", "Id");
        }
    }
}
