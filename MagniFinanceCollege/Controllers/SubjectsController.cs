/**
 * 
 * This Controller is only used to show views page
 * To see CRUD events go to Hubs folder
 * All dinamics connection are commenteds
 * because connection with database is fail
 * 
 */

using System.Linq;
using MagniFinanceCollege.Data;
using Microsoft.AspNetCore.Mvc;

namespace MagniFinanceCollege.Controllers
{
    public class SubjectsController : Controller
    {

        private readonly CollegeContext db;

        public SubjectsController(CollegeContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            // var data = db.Subjects.ToList();
            string data = null;
            return View(data);
        }

        public IActionResult Update(int id)
        {
            // var data = db.Subjects.Find(id);
            ViewBag.CourseId = "1";
            ViewBag.TeachearId = "3";
            ViewBag.SubjectName = "Geography";
            setViewBagStatic();

            return View();
        }

        public IActionResult Create()
        {
            string data = null;
            //var data = new
            //{
            //    Teachers = db.Teachers.ToList(),
            //    Courses = db.Courses.ToList(),
            //};

            setViewBagStatic();

            return View(data);
        }

        /**
         * Static Data to test
         */
        private void setViewBagStatic()
        {
            ViewBag.Teachers = new[]
            {
                new[] {"1","Dr. Carson Alexander"},
                new[] {"2","Mr. Arturo Anand"},
                new[] {"3","Dr. Gytis Barzdukas"},
                new[] {"4","Dr. Yan Li"},
                new[] {"5","Sir. Peggy Justice"},
                new[] {"6","Ms. Laura Norman"},
                new[] {"7","Dr. Meredith Alonso"}
            };
            ViewBag.Courses = new[]
            {
                new[]{ "1", "Chemistry" },
                new[]{ "2", "Microeconomics"},
                new[]{ "3", "Macroeconomics"},
                new[]{ "4", "Calculus"},
                new[]{ "5", "Trigonometry"},
                new[]{ "6", "Composition" },
                new[]{ "7", "Literature"}
            };
        }
    }
}
