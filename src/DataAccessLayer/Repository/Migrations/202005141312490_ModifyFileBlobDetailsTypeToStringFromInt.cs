namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyFileBlobDetailsTypeToStringFromInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FileBlobs", "Details", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FileBlobs", "Details", c => c.Int());
        }
    }
}
