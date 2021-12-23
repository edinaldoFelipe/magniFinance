/**
 * 
 * This Controller is only used to show views page
 * To see CRUD events go to Hubs folder
 * All dinamics connection are commenteds
 * because connection with database is fail
 * 
 */

using MagniFinanceCollege.Data;
using Microsoft.AspNetCore.Mvc;

namespace MagniFinanceCollege.Controllers
{
    public class TeachersController : Controller
    {

        private readonly CollegeContext db;

        public TeachersController(CollegeContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            // var data = db.Teachers.ToList();
            string data = null;
            return View(data);
        }

        public IActionResult Update(int id)
        {
            // var data = db.Teachers.Find(id);
            string data = null;
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
