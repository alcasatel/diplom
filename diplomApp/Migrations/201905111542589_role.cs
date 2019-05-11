namespace diplomApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AddintionalUserInfoes", newName: "Users");
            RenameColumn(table: "dbo.Results", name: "AddintionalUserInfoId", newName: "UserId");
            RenameIndex(table: "dbo.Results", name: "IX_AddintionalUserInfoId", newName: "IX_UserId");
            AddColumn("dbo.Users", "RoleId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RoleId");
            RenameIndex(table: "dbo.Results", name: "IX_UserId", newName: "IX_AddintionalUserInfoId");
            RenameColumn(table: "dbo.Results", name: "UserId", newName: "AddintionalUserInfoId");
            RenameTable(name: "dbo.Users", newName: "AddintionalUserInfoes");
        }
    }
}
