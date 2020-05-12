namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateManyToManyTablesParameters : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DocumentEntityWorkingPositionEntities", newName: "DocumentsModifyPositions");
            RenameTable(name: "dbo.DocumentEntityUserEntities", newName: "DocumentsReviewers");
            RenameTable(name: "dbo.DocumentEntityUserEntity1", newName: "DocumentsUsersWithApprove");
            RenameTable(name: "dbo.DocumentEntityUserEntity2", newName: "DocumentsUsersWithBlocking");
            RenameColumn(table: "dbo.DocumentsModifyPositions", name: "DocumentEntity_Id", newName: "Document_Id");
            RenameColumn(table: "dbo.DocumentsModifyPositions", name: "WorkingPositionEntity_Id", newName: "WorkingPosition_Id");
            RenameColumn(table: "dbo.DocumentsReviewers", name: "DocumentEntity_Id", newName: "Document_Id");
            RenameColumn(table: "dbo.DocumentsReviewers", name: "UserEntity_Id", newName: "User_Id");
            RenameColumn(table: "dbo.DocumentsUsersWithApprove", name: "DocumentEntity_Id", newName: "Document_Id");
            RenameColumn(table: "dbo.DocumentsUsersWithApprove", name: "UserEntity_Id", newName: "User_Id");
            RenameColumn(table: "dbo.DocumentsUsersWithBlocking", name: "DocumentEntity_Id", newName: "Document_Id");
            RenameColumn(table: "dbo.DocumentsUsersWithBlocking", name: "UserEntity_Id", newName: "User_Id");
            RenameIndex(table: "dbo.DocumentsModifyPositions", name: "IX_DocumentEntity_Id", newName: "IX_Document_Id");
            RenameIndex(table: "dbo.DocumentsModifyPositions", name: "IX_WorkingPositionEntity_Id", newName: "IX_WorkingPosition_Id");
            RenameIndex(table: "dbo.DocumentsReviewers", name: "IX_DocumentEntity_Id", newName: "IX_Document_Id");
            RenameIndex(table: "dbo.DocumentsReviewers", name: "IX_UserEntity_Id", newName: "IX_User_Id");
            RenameIndex(table: "dbo.DocumentsUsersWithApprove", name: "IX_DocumentEntity_Id", newName: "IX_Document_Id");
            RenameIndex(table: "dbo.DocumentsUsersWithApprove", name: "IX_UserEntity_Id", newName: "IX_User_Id");
            RenameIndex(table: "dbo.DocumentsUsersWithBlocking", name: "IX_DocumentEntity_Id", newName: "IX_Document_Id");
            RenameIndex(table: "dbo.DocumentsUsersWithBlocking", name: "IX_UserEntity_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.DocumentsUsersWithBlocking", name: "IX_User_Id", newName: "IX_UserEntity_Id");
            RenameIndex(table: "dbo.DocumentsUsersWithBlocking", name: "IX_Document_Id", newName: "IX_DocumentEntity_Id");
            RenameIndex(table: "dbo.DocumentsUsersWithApprove", name: "IX_User_Id", newName: "IX_UserEntity_Id");
            RenameIndex(table: "dbo.DocumentsUsersWithApprove", name: "IX_Document_Id", newName: "IX_DocumentEntity_Id");
            RenameIndex(table: "dbo.DocumentsReviewers", name: "IX_User_Id", newName: "IX_UserEntity_Id");
            RenameIndex(table: "dbo.DocumentsReviewers", name: "IX_Document_Id", newName: "IX_DocumentEntity_Id");
            RenameIndex(table: "dbo.DocumentsModifyPositions", name: "IX_WorkingPosition_Id", newName: "IX_WorkingPositionEntity_Id");
            RenameIndex(table: "dbo.DocumentsModifyPositions", name: "IX_Document_Id", newName: "IX_DocumentEntity_Id");
            RenameColumn(table: "dbo.DocumentsUsersWithBlocking", name: "User_Id", newName: "UserEntity_Id");
            RenameColumn(table: "dbo.DocumentsUsersWithBlocking", name: "Document_Id", newName: "DocumentEntity_Id");
            RenameColumn(table: "dbo.DocumentsUsersWithApprove", name: "User_Id", newName: "UserEntity_Id");
            RenameColumn(table: "dbo.DocumentsUsersWithApprove", name: "Document_Id", newName: "DocumentEntity_Id");
            RenameColumn(table: "dbo.DocumentsReviewers", name: "User_Id", newName: "UserEntity_Id");
            RenameColumn(table: "dbo.DocumentsReviewers", name: "Document_Id", newName: "DocumentEntity_Id");
            RenameColumn(table: "dbo.DocumentsModifyPositions", name: "WorkingPosition_Id", newName: "WorkingPositionEntity_Id");
            RenameColumn(table: "dbo.DocumentsModifyPositions", name: "Document_Id", newName: "DocumentEntity_Id");
            RenameTable(name: "dbo.DocumentsUsersWithBlocking", newName: "DocumentEntityUserEntity2");
            RenameTable(name: "dbo.DocumentsUsersWithApprove", newName: "DocumentEntityUserEntity1");
            RenameTable(name: "dbo.DocumentsReviewers", newName: "DocumentEntityUserEntities");
            RenameTable(name: "dbo.DocumentsModifyPositions", newName: "DocumentEntityWorkingPositionEntities");
        }
    }
}
