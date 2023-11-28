namespace EduLearnMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Poprawki : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupCourses", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.GroupCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Tests", "GroupID", "dbo.Groups");
            DropIndex("dbo.Tests", new[] { "GroupID" });
            DropIndex("dbo.GroupCourses", new[] { "Group_GroupID" });
            DropIndex("dbo.GroupCourses", new[] { "Course_CourseID" });
            RenameColumn(table: "dbo.Tests", name: "GroupID", newName: "Group_GroupID");
            AddColumn("dbo.TestResults", "GroupID", c => c.Int(nullable: false));
            AddColumn("dbo.CourseDescriptions", "GroupID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tests", "Group_GroupID", c => c.Int());
            CreateIndex("dbo.CourseDescriptions", "CourseID");
            CreateIndex("dbo.CourseDescriptions", "GroupID");
            CreateIndex("dbo.Groups", "CourseID");
            CreateIndex("dbo.Tests", "Group_GroupID");
            CreateIndex("dbo.TestResults", "GroupID");
            AddForeignKey("dbo.CourseDescriptions", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.CourseDescriptions", "GroupID", "dbo.Groups", "GroupID", cascadeDelete: true);
            AddForeignKey("dbo.TestResults", "GroupID", "dbo.Groups", "GroupID", cascadeDelete: true);
            AddForeignKey("dbo.Groups", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Tests", "Group_GroupID", "dbo.Groups", "GroupID");
            DropTable("dbo.GroupCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GroupCourses",
                c => new
                    {
                        Group_GroupID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_GroupID, t.Course_CourseID });
            
            DropForeignKey("dbo.Tests", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.Groups", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.TestResults", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.CourseDescriptions", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.CourseDescriptions", "CourseID", "dbo.Courses");
            DropIndex("dbo.TestResults", new[] { "GroupID" });
            DropIndex("dbo.Tests", new[] { "Group_GroupID" });
            DropIndex("dbo.Groups", new[] { "CourseID" });
            DropIndex("dbo.CourseDescriptions", new[] { "GroupID" });
            DropIndex("dbo.CourseDescriptions", new[] { "CourseID" });
            AlterColumn("dbo.Tests", "Group_GroupID", c => c.Int(nullable: false));
            DropColumn("dbo.CourseDescriptions", "GroupID");
            DropColumn("dbo.TestResults", "GroupID");
            RenameColumn(table: "dbo.Tests", name: "Group_GroupID", newName: "GroupID");
            CreateIndex("dbo.GroupCourses", "Course_CourseID");
            CreateIndex("dbo.GroupCourses", "Group_GroupID");
            CreateIndex("dbo.Tests", "GroupID");
            AddForeignKey("dbo.Tests", "GroupID", "dbo.Groups", "GroupID", cascadeDelete: true);
            AddForeignKey("dbo.GroupCourses", "Course_CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.GroupCourses", "Group_GroupID", "dbo.Groups", "GroupID", cascadeDelete: true);
        }
    }
}
