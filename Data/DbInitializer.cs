using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeBook.Models;

namespace GradeBook.Data
{
    public class DbInitializer
    {
        public static void Initialize(GradeContext context)
        {
            context.Database.EnsureCreated();
            Console.WriteLine("here");
            // Look for any students.   

            var students = new Student[]
            {
                new Student{FirstName="Carson",SecondName="Alexander", DateOfBirth="20/01/2000", Major="CSSE", },
                new Student{FirstName="Carson",SecondName="Kamila", DateOfBirth="13/01/1999", Major="IS", },
                new Student{FirstName="Pablo",SecondName="Camel", DateOfBirth="12/01/2000", Major="IS", },
                new Student{FirstName="Dog",SecondName="Snoop", DateOfBirth="4/01/2000", Major="IS", },
                new Student{FirstName="Lil",SecondName="Uzi Vert", DateOfBirth="4/01/2000", Major="CSSE", },
                new Student{FirstName="21",SecondName="Savage", DateOfBirth="4/01/2000", Major="CSSE", }

            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var groupes = new Group[]
            {
                new Group{ID=1050,Name="CSSE-1703"},
                new Group{ID=4022,Name="IS-1704"},
            };
            foreach (Group c in groupes)
            {
                context.Groups.Add(c);
            }
            context.SaveChanges();

        }
    }
}
