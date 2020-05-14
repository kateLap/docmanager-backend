namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneFileBlobToManyVersions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DocumentVersions", "Id", "dbo.FileBlobs");
            DropIndex("dbo.DocumentVersions", new[] { "Id" });
            DropPrimaryKey("dbo.DocumentVersions");
            AddColumn("dbo.DocumentVersions", "FileBlob_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.DocumentVersions", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DocumentVersions", "Id");
            CreateIndex("dbo.DocumentVersions", "FileBlob_Id");
            AddForeignKey("dbo.DocumentVersions", "FileBlob_Id", "dbo.FileBlobs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocumentVersions", "FileBlob_Id", "dbo.FileBlobs");
            DropIndex("dbo.DocumentVersions", new[] { "FileBlob_Id" });
            DropPrimaryKey("dbo.DocumentVersions");
            AlterColumn("dbo.DocumentVersions", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.DocumentVersions", "FileBlob_Id");
            AddPrimaryKey("dbo.DocumentVersions", "Id");
            CreateIndex("dbo.DocumentVersions", "Id");
            AddForeignKey("dbo.DocumentVersions", "Id", "dbo.FileBlobs", "Id");
        }
    }
}
