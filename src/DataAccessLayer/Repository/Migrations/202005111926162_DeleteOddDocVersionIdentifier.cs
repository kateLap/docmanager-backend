namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteOddDocVersionIdentifier : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FileBlobs", "Name", c => c.String());
            DropColumn("dbo.DocumentVersions", "VersionNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DocumentVersions", "VersionNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.FileBlobs", "Name", c => c.String(nullable: false));
        }
    }
}
