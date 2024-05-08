using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.Models.Admin;

namespace School_Management_System.Controllers.Admin
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext db;

        public DashboardController(ApplicationDbContext _db)
        {
            db = _db;
        }


        public IActionResult Index()
        {
            List<TeacherDetails> objList = db.Teachers.ToList();
            return View(objList);
        }
    }
}
