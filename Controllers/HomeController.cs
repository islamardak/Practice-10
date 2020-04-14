using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GradeBook.Models;
using GradeBook.Data;
using System.Text.RegularExpressions;
namespace GradeBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly GradeContext _context;

        public HomeController (GradeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var students = _context.Groups.ToList<Models.Group>();
            
            ViewData["Groups"] = students;
            
            return View();
        }

        public IActionResult Group(int id)
        {
            var studs = _context.Students.Where(g => g.GroupId == id).ToList<Student>();
            var studIds = _context.Students.Where(g => g.GroupId == id).Select(s => s.ID).ToList<int>();
            ViewData["Group"] = studs;
            ViewData["SubjectList"] = _context.Subjects.ToList<Subject>();

            ViewData["StudMarks"] = _context.StudentSubjectMarks.Where(c => studIds.Contains(c.StudentId)).ToList<StudentSubjectMark>();
            ViewData["MarkISB"] = _context.Marks.ToList<Mark>();
            return View();
        }

        public IActionResult Student(int studentId, string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                Regex regex = new Regex(@"^\d[A-Z][A-Z]\d{5}$");
                if (regex.Match(SearchString).Success)
                {
                    var student = _context.Students.Where(c => c.GroupId == SearchString[0]
                                                            && c.FirstName[0] == SearchString[1]
                                                            && c.SecondName[0] == SearchString[2]
                                                            && c.DateOfBirth[-1] == SearchString[-1]
                                                            && c.DateOfBirth.Substring(0, 2) == SearchString.Substring(3, 2)
                                                            && c.DateOfBirth.Substring(3, 2) == SearchString.Substring(5, 2)).SingleOrDefault();
                    ViewData["Student"] = student as Student;
                    ViewData["Group"] = _context.Groups.Where(c => c.ID == student.GroupId).SingleOrDefault();
                    return View();
                }
                else
                {
                    //АШИБКА
                    throw new Exception();
                }
            }
            var groupId = _context.Students.Where(s => s.ID == studentId).Select(u => u.GroupId).SingleOrDefault();
            ViewData["Group"] = _context.Groups.Where(g => g.ID == groupId).SingleOrDefault();
            ViewData["Student"] = _context.Students.Where(s => s.ID == studentId).SingleOrDefault() as Student;
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
