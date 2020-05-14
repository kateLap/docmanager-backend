namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionalFileBlobContent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FileBlobs", "Content", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FileBlobs", "Content", c => c.Binary(nullable: false));
        }
    }
}
