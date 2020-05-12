namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteBlockingUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DocumentsUsersWithBlocking", "Document_Id", "dbo.Documents");
            DropForeignKey("dbo.DocumentsUsersWithBlocking", "User_Id", "dbo.Users");
            DropIndex("dbo.DocumentsUsersWithBlocking", new[] { "Document_Id" });
            DropIndex("dbo.DocumentsUsersWithBlocking", new[] { "User_Id" });
            DropTable("dbo.DocumentsUsersWithBlocking");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DocumentsUsersWithBlocking",
                c => new
                    {
                        Document_Id = c.Int(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Document_Id, t.User_Id });
            
            CreateIndex("dbo.DocumentsUsersWithBlocking", "User_Id");
            CreateIndex("dbo.DocumentsUsersWithBlocking", "Document_Id");
            AddForeignKey("dbo.DocumentsUsersWithBlocking", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DocumentsUsersWithBlocking", "Document_Id", "dbo.Documents", "Id", cascadeDelete: true);
        }
    }
}
