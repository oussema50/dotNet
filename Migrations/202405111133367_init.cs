namespace projetDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentRefId = c.Int(nullable: false),
                        CourseRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentRefId, t.CourseRefId })
                .ForeignKey("dbo.Students", t => t.StudentRefId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseRefId, cascadeDelete: true)
                .Index(t => t.StudentRefId)
                .Index(t => t.CourseRefId);
            
            CreateTable(
                "dbo.TeacherCourse",
                c => new
                    {
                        TeacherRefId = c.Int(nullable: false),
                        CourseRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherRefId, t.CourseRefId })
                .ForeignKey("dbo.Teachers", t => t.TeacherRefId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseRefId, cascadeDelete: true)
                .Index(t => t.TeacherRefId)
                .Index(t => t.CourseRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherCourse", "CourseRefId", "dbo.Courses");
            DropForeignKey("dbo.TeacherCourse", "TeacherRefId", "dbo.Teachers");
            DropForeignKey("dbo.StudentCourse", "CourseRefId", "dbo.Courses");
            DropForeignKey("dbo.StudentCourse", "StudentRefId", "dbo.Students");
            DropIndex("dbo.TeacherCourse", new[] { "CourseRefId" });
            DropIndex("dbo.TeacherCourse", new[] { "TeacherRefId" });
            DropIndex("dbo.StudentCourse", new[] { "CourseRefId" });
            DropIndex("dbo.StudentCourse", new[] { "StudentRefId" });
            DropTable("dbo.TeacherCourse");
            DropTable("dbo.StudentCourse");
        }
    }
}
