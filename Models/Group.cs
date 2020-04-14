using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.Models
{
    public class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
