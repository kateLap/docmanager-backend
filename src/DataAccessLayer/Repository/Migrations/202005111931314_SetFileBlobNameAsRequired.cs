﻿namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetFileBlobNameAsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FileBlobs", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FileBlobs", "Name", c => c.String());
        }
    }
}
