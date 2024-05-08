using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;




namespace School_Management_System.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApplicationDbContext db;

        public AuthenticationController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login loginModel)
        {
            var existingAdmin = db.AdminCredential.FirstOrDefault(admin => admin.Email == loginModel.Email && admin.Password == loginModel.Password);
            var existingTeacher = db.Teachers.FirstOrDefault(teacher => teacher.TeacherEmail == loginModel.Email && teacher.Password == loginModel.Password);
            var existingStudent = db.students.FirstOrDefault(student => student.StudentEmail == loginModel.Email && student.Password == loginModel.Password);
            var existingParent = db.Parents.FirstOrDefault(parent => parent.ParentEmail == loginModel.Email && parent.Password == loginModel.Password);

            if (ModelState.IsValid && existingAdmin != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else if (ModelState.IsValid && existingTeacher != null)
            {
                HttpContext.Session.SetString("TeacherEmail", existingTeacher.TeacherEmail.ToString());
                return RedirectToAction("Index", "TeacherDashboard");
            }
            else if (ModelState.IsValid && existingStudent != null)
            {
                HttpContext.Session.SetString("StudentEmail", existingStudent.StudentEmail.ToString());
                return RedirectToAction("Index", "StudentDashboard");
            }
            else if (ModelState.IsValid && existingParent != null)
            {
                HttpContext.Session.SetString("ParentEmail", existingParent.ParentEmail.ToString());
                return RedirectToAction("Index", "ParentDashboard");
            }

            // If ModelState is not valid or login fails, return to the login view
            TempData["error"] = "Invalid Email or Password";
            ModelState.Clear();
            return View("Login");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
