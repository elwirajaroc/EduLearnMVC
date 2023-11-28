namespace EduLearnMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        Content = c.String(),
                        Date_published = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdministratorID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdministratorID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Subject_name = c.String(),
                        Description = c.String(),
                        TeacherID = c.Int(nullable: false),
                        AdministratorID = c.Int(nullable: false),
                        Start_date = c.DateTime(nullable: false),
                        End_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Administrators", t => t.AdministratorID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.AdministratorID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        Group_number = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        Date_scheduled = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestID)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Question_text = c.String(),
                        Points = c.Int(nullable: false),
                        TestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Tests", t => t.TestID, cascadeDelete: true)
                .Index(t => t.TestID);
            
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        TestResultID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        TestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestResultID)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.TestID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherID);
            
            CreateTable(
                "dbo.ClosedQuestions",
                c => new
                    {
                        ClosedQuestionID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.ClosedQuestionID);
            
            CreateTable(
                "dbo.CourseDescriptions",
                c => new
                    {
                        CourseDescriptionID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Detailed_description = c.String(),
                    })
                .PrimaryKey(t => t.CourseDescriptionID);
            
            CreateTable(
                "dbo.OpenQuestions",
                c => new
                    {
                        OpenQuestionID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OpenQuestionID);
            
            CreateTable(
                "dbo.GroupCourses",
                c => new
                    {
                        Group_GroupID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_GroupID, t.Course_CourseID })
                .ForeignKey("dbo.Groups", t => t.Group_GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Group_GroupID)
                .Index(t => t.Course_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "TestID", "dbo.Tests");
            DropForeignKey("dbo.TestResults", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Courses", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Questions", "TestID", "dbo.Tests");
            DropForeignKey("dbo.Tests", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.Students", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.GroupCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.GroupCourses", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.Courses", "AdministratorID", "dbo.Administrators");
            DropForeignKey("dbo.Messages", "AccountID", "dbo.Accounts");
            DropIndex("dbo.GroupCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.GroupCourses", new[] { "Group_GroupID" });
            DropIndex("dbo.TestResults", new[] { "TestID" });
            DropIndex("dbo.TestResults", new[] { "TeacherID" });
            DropIndex("dbo.Questions", new[] { "TestID" });
            DropIndex("dbo.Tests", new[] { "GroupID" });
            DropIndex("dbo.Students", new[] { "GroupID" });
            DropIndex("dbo.Courses", new[] { "AdministratorID" });
            DropIndex("dbo.Courses", new[] { "TeacherID" });
            DropIndex("dbo.Messages", new[] { "AccountID" });
            DropTable("dbo.GroupCourses");
            DropTable("dbo.OpenQuestions");
            DropTable("dbo.CourseDescriptions");
            DropTable("dbo.ClosedQuestions");
            DropTable("dbo.Teachers");
            DropTable("dbo.TestResults");
            DropTable("dbo.Questions");
            DropTable("dbo.Tests");
            DropTable("dbo.Students");
            DropTable("dbo.Groups");
            DropTable("dbo.Courses");
            DropTable("dbo.Administrators");
            DropTable("dbo.Messages");
            DropTable("dbo.Accounts");
        }
    }
}
