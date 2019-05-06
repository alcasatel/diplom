namespace diplomApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueIds : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AddintionalUserInfoes", "Id", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AddintionalUserInfoes", new[] { "Id" });
        }
    }
}
