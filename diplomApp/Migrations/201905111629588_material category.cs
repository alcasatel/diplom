namespace diplomApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class materialcategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materials", "Category");
        }
    }
}
