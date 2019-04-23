namespace diplomApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddintionalUserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        vkId = c.Long(nullable: false),
                        Email = c.String(),
                        FullName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Education = c.String(),
                        ResultPercent = c.Int(nullable: false),
                        PathToAvatar = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AddintionalUserInfoes");
        }
    }
}
