namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveFileNameFromBlobToDocVersion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentVersions", "Name", c => c.String(nullable: false));
            AddColumn("dbo.FileBlobs", "Details", c => c.Int());
            DropColumn("dbo.FileBlobs", "Name");
            DropColumn("dbo.FileBlobs", "Length");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileBlobs", "Length", c => c.Int());
            AddColumn("dbo.FileBlobs", "Name", c => c.String(nullable: false));
            DropColumn("dbo.FileBlobs", "Details");
            DropColumn("dbo.DocumentVersions", "Name");
        }
    }
}
