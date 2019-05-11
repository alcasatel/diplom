namespace diplomApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class materials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(),
                        AddintionalUserInfoId = c.Int(),
                        LessonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddintionalUserInfoes", t => t.AddintionalUserInfoId)
                .ForeignKey("dbo.Lessons", t => t.LessonId)
                .Index(t => t.AddintionalUserInfoId)
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        About = c.String(),
                        MaxResult = c.Int(nullable: false),
                        PathToPage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Annotation = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        PathToPageContent = c.String(),
                        Image = c.String(),
                        MaterialTypeId = c.Int(),
                        Tags = c.String(),
                        Lesson_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId)
                .ForeignKey("dbo.Lessons", t => t.Lesson_Id)
                .Index(t => t.MaterialTypeId)
                .Index(t => t.Lesson_Id);
            
            CreateTable(
                "dbo.MaterialTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        About = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Materials", "Lesson_Id", "dbo.Lessons");
            DropForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.Results", "AddintionalUserInfoId", "dbo.AddintionalUserInfoes");
            DropIndex("dbo.Materials", new[] { "Lesson_Id" });
            DropIndex("dbo.Materials", new[] { "MaterialTypeId" });
            DropIndex("dbo.Results", new[] { "LessonId" });
            DropIndex("dbo.Results", new[] { "AddintionalUserInfoId" });
            DropTable("dbo.MaterialTypes");
            DropTable("dbo.Materials");
            DropTable("dbo.Lessons");
            DropTable("dbo.Results");
        }
    }
}
