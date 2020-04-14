using GradeBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.Data
{
    public class GradeContext : DbContext
    {
        public GradeContext(DbContextOptions<GradeContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<StudentSubjectMark> StudentSubjectMarks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student").HasData(
                new Student { ID = 1, FirstName = "Carson", SecondName = "Alexander", DateOfBirth = "20/01/2000", Major = "CSSE", GroupId= 4022 },
                new Student { ID = 2, FirstName = "Carson", SecondName = "Kamila", DateOfBirth = "13/01/1999", Major = "IS", GroupId = 4022 },
                new Student { ID = 3, FirstName = "Pablo", SecondName = "Camel", DateOfBirth = "12/01/2000", Major = "IS", GroupId = 4022 },
                new Student { ID = 4, FirstName = "Dog", SecondName = "Snoop", DateOfBirth = "4/01/2000", Major = "IS", GroupId = 1050 },
                new Student { ID = 5, FirstName = "Lil", SecondName = "Uzi Vert", DateOfBirth = "4/01/2000", Major = "CSSE", GroupId = 1050 },
                new Student { ID = 6, FirstName = "21", SecondName = "Savage", DateOfBirth = "4/01/2000", Major = "CSSE", GroupId = 1050 });

            modelBuilder.Entity<Group>().ToTable("Group").HasData(
                new Group { ID = 1050, Name = "CSSE-1703" },
                new Group { ID = 4022, Name = "IS-1704" });

            modelBuilder.Entity<Subject>().ToTable("Subject").HasData(
                new Subject { ID = 1, Name = "Math" },
                new Subject { ID = 2, Name = "Physics" },
                new Subject { ID = 3, Name = "ASP.NET Core" },
                new Subject { ID = 4, Name = "Relational Math" });

            modelBuilder.Entity<Mark>().ToTable("Mark").HasData(
                new Mark { ID = 1, Sign = "A" },
                new Mark { ID = 2, Sign = "B" },
                new Mark { ID = 3, Sign = "C" },
                new Mark { ID = 4, Sign = "D" });


            modelBuilder.Entity<StudentSubjectMark>()
                .HasKey(bc => new { bc.StudentId, bc.SubjectId, bc.MarkId });
            modelBuilder.Entity<StudentSubjectMark>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjectMarks)
                .HasForeignKey(ss => ss.StudentId);
            modelBuilder.Entity<StudentSubjectMark>()
                .HasOne(ss => ss.Subject)
                .WithMany(sub => sub.StudentSubjectMarks)
                .HasForeignKey(ss => ss.SubjectId);
            modelBuilder.Entity<StudentSubjectMark>()
                .HasOne(ss => ss.Mark)
                .WithMany(sub => sub.StudentSubjectMarks)
                .HasForeignKey(ss => ss.MarkId);

            modelBuilder.Entity<StudentSubjectMark>().ToTable("StudentSubjectMark").HasData(
                new StudentSubjectMark { StudentId = 1, SubjectId = 1, MarkId = 1 },
                new StudentSubjectMark { StudentId = 1, SubjectId = 2, MarkId = 2 },
                new StudentSubjectMark { StudentId = 1, SubjectId = 3, MarkId = 3 },
                new StudentSubjectMark { StudentId = 1, SubjectId = 4, MarkId = 4 },

                new StudentSubjectMark { StudentId = 2, SubjectId = 1, MarkId = 2 },
                new StudentSubjectMark { StudentId = 2, SubjectId = 2, MarkId = 1 },
                new StudentSubjectMark { StudentId = 2, SubjectId = 3, MarkId = 1 },
                new StudentSubjectMark { StudentId = 2, SubjectId = 4, MarkId = 1 },

                new StudentSubjectMark { StudentId = 3, SubjectId = 1, MarkId = 1 },
                new StudentSubjectMark { StudentId = 3, SubjectId = 2, MarkId = 1 },
                new StudentSubjectMark { StudentId = 3, SubjectId = 3, MarkId = 1 },
                new StudentSubjectMark { StudentId = 3, SubjectId = 4, MarkId = 1 },

                new StudentSubjectMark { StudentId = 4, SubjectId = 1, MarkId = 1 },
                new StudentSubjectMark { StudentId = 4, SubjectId = 2, MarkId = 1 },
                new StudentSubjectMark { StudentId = 4, SubjectId = 3, MarkId = 1 },
                new StudentSubjectMark { StudentId = 4, SubjectId = 4, MarkId = 1 },

                new StudentSubjectMark { StudentId = 5, SubjectId = 1, MarkId = 1 },
                new StudentSubjectMark { StudentId = 5, SubjectId = 2, MarkId = 1 },
                new StudentSubjectMark { StudentId = 5, SubjectId = 3, MarkId = 1 },
                new StudentSubjectMark { StudentId = 5, SubjectId = 4, MarkId = 1 },

                new StudentSubjectMark { StudentId = 6, SubjectId = 1, MarkId = 1 },
                new StudentSubjectMark { StudentId = 6, SubjectId = 2, MarkId = 1 },
                new StudentSubjectMark { StudentId = 6, SubjectId = 3, MarkId = 1 },
                new StudentSubjectMark { StudentId = 6, SubjectId = 4, MarkId = 1 });

        }

    }
}
