using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

//Mechanizm Migrations
//1. Enable-Migrations - raz na początku życia projektu
//2a. Add-Migration NAZWA - po zmianie modeli
//2b. Update-Database - zmiana po stronie bazy danych 

namespace EduLearnMVC.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyCS") { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDescription> CourseDescriptions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ClosedQuestion> ClosedQuestions { get; set; }
        public DbSet<OpenQuestion> OpenQuestions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
    }
}            



