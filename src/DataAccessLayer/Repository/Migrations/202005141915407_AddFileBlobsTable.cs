namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileBlobsTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DocumentVersions");
            CreateTable(
                "dbo.FileBlobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.DocumentVersions", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DocumentVersions", "Id");
            CreateIndex("dbo.DocumentVersions", "Id");
            AddForeignKey("dbo.DocumentVersions", "Id", "dbo.FileBlobs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocumentVersions", "Id", "dbo.FileBlobs");
            DropIndex("dbo.DocumentVersions", new[] { "Id" });
            DropPrimaryKey("dbo.DocumentVersions");
            AlterColumn("dbo.DocumentVersions", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.FileBlobs");
            AddPrimaryKey("dbo.DocumentVersions", "Id");
        }
    }
}
