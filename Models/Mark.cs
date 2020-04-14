using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.Models
{
    public class Mark
    {
        public int ID { get; set; }
        public string Sign { get; set; }

        public ICollection<StudentSubjectMark> StudentSubjectMarks { get; set; }
    }
}
