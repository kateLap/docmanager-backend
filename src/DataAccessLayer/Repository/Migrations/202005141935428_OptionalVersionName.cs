namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionalVersionName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DocumentVersions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DocumentVersions", "Name", c => c.String(nullable: false));
        }
    }
}
