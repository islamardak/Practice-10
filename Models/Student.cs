using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string DateOfBirth { get; set; }
        public string Major { get; set; }
        public int GroupId { get; set; }

        public Group Group { get; set; }
        public ICollection<StudentSubjectMark> StudentSubjectMarks { get; set; }

    }
}
