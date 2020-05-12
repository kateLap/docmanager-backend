namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FileBlobs", "Length", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FileBlobs", "Length", c => c.Int(nullable: false));
        }
    }
}
