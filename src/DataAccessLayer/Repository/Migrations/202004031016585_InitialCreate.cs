namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Status_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Statuses", t => t.Status_Id, cascadeDelete: true)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.DocumentVersions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VersionNumber = c.Int(nullable: false),
                        Document_Id = c.Int(nullable: false),
                        FileBlob_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.Document_Id, cascadeDelete: true)
                .ForeignKey("dbo.FileBlobs", t => t.FileBlob_Id)
                .Index(t => t.Document_Id)
                .Index(t => t.FileBlob_Id);
            
            CreateTable(
                "dbo.FileBlobs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Length = c.Int(nullable: false),
                        Content = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkingPositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        WorkingPosition_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkingPositions", t => t.WorkingPosition_Id, cascadeDelete: true)
                .Index(t => t.WorkingPosition_Id);
            
            CreateTable(
                "dbo.Statuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentEntityWorkingPositionEntities",
                c => new
                    {
                        DocumentEntity_Id = c.Int(nullable: false),
                        WorkingPositionEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocumentEntity_Id, t.WorkingPositionEntity_Id })
                .ForeignKey("dbo.Documents", t => t.DocumentEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkingPositions", t => t.WorkingPositionEntity_Id, cascadeDelete: true)
                .Index(t => t.DocumentEntity_Id)
                .Index(t => t.WorkingPositionEntity_Id);
            
            CreateTable(
                "dbo.DocumentEntityUserEntities",
                c => new
                    {
                        DocumentEntity_Id = c.Int(nullable: false),
                        UserEntity_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocumentEntity_Id, t.UserEntity_Id })
                .ForeignKey("dbo.Documents", t => t.DocumentEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserEntity_Id, cascadeDelete: true)
                .Index(t => t.DocumentEntity_Id)
                .Index(t => t.UserEntity_Id);
            
            CreateTable(
                "dbo.DocumentEntityUserEntity1",
                c => new
                    {
                        DocumentEntity_Id = c.Int(nullable: false),
                        UserEntity_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocumentEntity_Id, t.UserEntity_Id })
                .ForeignKey("dbo.Documents", t => t.DocumentEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserEntity_Id, cascadeDelete: true)
                .Index(t => t.DocumentEntity_Id)
                .Index(t => t.UserEntity_Id);
            
            CreateTable(
                "dbo.DocumentEntityUserEntity2",
                c => new
                    {
                        DocumentEntity_Id = c.Int(nullable: false),
                        UserEntity_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocumentEntity_Id, t.UserEntity_Id })
                .ForeignKey("dbo.Documents", t => t.DocumentEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserEntity_Id, cascadeDelete: true)
                .Index(t => t.DocumentEntity_Id)
                .Index(t => t.UserEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocumentEntityUserEntity2", "UserEntity_Id", "dbo.Users");
            DropForeignKey("dbo.DocumentEntityUserEntity2", "DocumentEntity_Id", "dbo.Documents");
            DropForeignKey("dbo.DocumentEntityUserEntity1", "UserEntity_Id", "dbo.Users");
            DropForeignKey("dbo.DocumentEntityUserEntity1", "DocumentEntity_Id", "dbo.Documents");
            DropForeignKey("dbo.Documents", "Status_Id", "dbo.Statuses");
            DropForeignKey("dbo.DocumentEntityUserEntities", "UserEntity_Id", "dbo.Users");
            DropForeignKey("dbo.DocumentEntityUserEntities", "DocumentEntity_Id", "dbo.Documents");
            DropForeignKey("dbo.DocumentEntityWorkingPositionEntities", "WorkingPositionEntity_Id", "dbo.WorkingPositions");
            DropForeignKey("dbo.DocumentEntityWorkingPositionEntities", "DocumentEntity_Id", "dbo.Documents");
            DropForeignKey("dbo.Users", "WorkingPosition_Id", "dbo.WorkingPositions");
            DropForeignKey("dbo.DocumentVersions", "FileBlob_Id", "dbo.FileBlobs");
            DropForeignKey("dbo.DocumentVersions", "Document_Id", "dbo.Documents");
            DropIndex("dbo.DocumentEntityUserEntity2", new[] { "UserEntity_Id" });
            DropIndex("dbo.DocumentEntityUserEntity2", new[] { "DocumentEntity_Id" });
            DropIndex("dbo.DocumentEntityUserEntity1", new[] { "UserEntity_Id" });
            DropIndex("dbo.DocumentEntityUserEntity1", new[] { "DocumentEntity_Id" });
            DropIndex("dbo.DocumentEntityUserEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.DocumentEntityUserEntities", new[] { "DocumentEntity_Id" });
            DropIndex("dbo.DocumentEntityWorkingPositionEntities", new[] { "WorkingPositionEntity_Id" });
            DropIndex("dbo.DocumentEntityWorkingPositionEntities", new[] { "DocumentEntity_Id" });
            DropIndex("dbo.Users", new[] { "WorkingPosition_Id" });
            DropIndex("dbo.DocumentVersions", new[] { "FileBlob_Id" });
            DropIndex("dbo.DocumentVersions", new[] { "Document_Id" });
            DropIndex("dbo.Documents", new[] { "Status_Id" });
            DropTable("dbo.DocumentEntityUserEntity2");
            DropTable("dbo.DocumentEntityUserEntity1");
            DropTable("dbo.DocumentEntityUserEntities");
            DropTable("dbo.DocumentEntityWorkingPositionEntities");
            DropTable("dbo.Statuses");
            DropTable("dbo.Users");
            DropTable("dbo.WorkingPositions");
            DropTable("dbo.FileBlobs");
            DropTable("dbo.DocumentVersions");
            DropTable("dbo.Documents");
        }
    }
}
