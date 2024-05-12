using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace projetDotNet.Models
{
    public class TekupContext: DbContext
    {
        public TekupContext() : base("TekupConnectionString") {
        
        }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Course> courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                        .HasMany<Course>(s => s.Courses)
                        .WithMany(c => c.Students)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("StudentRefId");
                            cs.MapRightKey("CourseRefId");
                            cs.ToTable("StudentCourse");
                        });
            modelBuilder.Entity<Teacher>()
                        .HasMany<Course>(s => s.Courses)
                        .WithMany(c => c.Teachers)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("TeacherRefId");
                            cs.MapRightKey("CourseRefId");
                            cs.ToTable("TeacherCourse");
                        });

        }

    }

}