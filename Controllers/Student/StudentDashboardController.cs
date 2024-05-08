using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models.Admin;
using School_Management_System.Models.Teacher;

namespace School_Management_System.Controllers.Student
{
    public class StudentDashboardController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly IWebHostEnvironment _environment;

        public StudentDashboardController(ApplicationDbContext _db, IWebHostEnvironment he)
        {
            db = _db;
            _environment = he;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewSubjects()
        {
            // Step 1: Retrieve the student's email from the session
            var studentEmail = HttpContext.Session.GetString("StudentEmail");

            if (string.IsNullOrEmpty(studentEmail))
            {
                // Handle the case when the student email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the student in the database
            var student = db.students.FirstOrDefault(t => t.StudentEmail == studentEmail);

            if (student == null)
            {
                // Handle the case when the student is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve the student's class
            var studentClass = db.Class.FirstOrDefault(c => c.ClassId == student.ClassId);

            if (studentClass == null)
            {
                // Handle the case when the student's class is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 4: Retrieve the subjects associated with the student's class
            var subjects = db.subjets.Where(s => s.ClassId == student.ClassId).ToList();

            // Step 5: Pass the list of subjects to the view
            return View(subjects);
        }

        public IActionResult ViewMaterials()
        {
            // Step 1: Retrieve the student's email from the session
            var studentEmail = HttpContext.Session.GetString("StudentEmail");

            if (string.IsNullOrEmpty(studentEmail))
            {
                // Handle the case when the student email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the student in the database
            var student = db.students.FirstOrDefault(t => t.StudentEmail == studentEmail);

            if (student == null)
            {
                // Handle the case when the student is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve the student's class
            var studentClass = db.Class.FirstOrDefault(c => c.ClassId == student.ClassId);

            if (studentClass == null)
            {
                // Handle the case when the student's class is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 4: Retrieve the subjects associated with the student's class
            var subjects = db.subjets.Where(s => s.ClassId == student.ClassId).ToList();

            // Step 5: Pass the list of subjects to the view
            return View(subjects);

        }

        public IActionResult ViewUploadedMaterials(int subjectId)
        {
            // Step 1: Retrieve the student's email from the session
            var studentEmail = HttpContext.Session.GetString("StudentEmail");

            if (string.IsNullOrEmpty(studentEmail))
            {
                // Handle the case when the student email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the student in the database
            var student = db.students.FirstOrDefault(s => s.StudentEmail == studentEmail);

            if (student == null)
            {
                // Handle the case when the student is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve the student's class
            var studentClass = db.Class.FirstOrDefault(c => c.ClassId == student.ClassId);

            if (studentClass == null)
            {
                // Handle the case when the student's class is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 4: Retrieve the learning materials for the student's class
            var learningMaterials = db.LearningMaterials
                .Include(lm => lm.Subject)
                .Include(lm => lm.Subject.Class)
                .Where(lm => lm.ClassId == studentClass.ClassId && lm.SubjectId == subjectId)
                .ToList();

            return View(learningMaterials);
        }

        public IActionResult DownloadMaterial(int id)
        {
            var learningMaterial = db.LearningMaterials.FirstOrDefault(lm => lm.Id == id);
            if (learningMaterial == null)
                return NotFound();

            var filePath = learningMaterial.FilePath;
            var fileName = learningMaterial.FileName;

            var fileStream = System.IO.File.OpenRead(filePath);
            return File(fileStream, "application/octet-stream", fileName);
        }

        public IActionResult ViewAttendance()
        {
            // Step 1: Retrieve the student's email from the session
            var studentEmail = HttpContext.Session.GetString("StudentEmail");

            if (string.IsNullOrEmpty(studentEmail))
            {
                // Handle the case when the student email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the student in the database
            var student = db.students.FirstOrDefault(t => t.StudentEmail == studentEmail);

            if (student == null)
            {
                // Handle the case when the student is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve the student's class
            var studentClass = db.Class.FirstOrDefault(c => c.ClassId == student.ClassId);

            if (studentClass == null)
            {
                // Handle the case when the student's class is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 4: Retrieve the subjects associated with the student's class
            var subjects = db.subjets.Where(s => s.ClassId == student.ClassId).ToList();

            // Step 5: Pass the list of subjects to the view
            return View(subjects);
        }

        public IActionResult ViewAttendanceRecord(int subjectId)
        {
            // Step 1: Retrieve the student's email from the session
            var studentEmail = HttpContext.Session.GetString("StudentEmail");

            if (string.IsNullOrEmpty(studentEmail))
            {
                // Handle the case when the student email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the student in the database
            var student = db.students.Include(s => s.Class).FirstOrDefault(s => s.StudentEmail == studentEmail);

            if (student == null)
            {
                // Handle the case when the student is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Check if the student's class is null
            if (student.Class == null)
            {
                // Handle the case when the student's class is not found
                return RedirectToAction("Error", "Home"); // Redirect to an error page or handle accordingly
            }

            // Step 3: Retrieve all attendance records for the specified student and subject
            var attendanceRecords = db.StudentAttendances
                .Where(sa => sa.ClassId == student.ClassId && sa.SubjectId == subjectId && sa.StudentId == student.StudentId)
                .ToList();

            // Step 4: Create a ViewModel to represent the student's attendance records
            var viewModel = new List<StudentAttendance>();

            // Populate the ViewModel with attendance records
            foreach (var record in attendanceRecords)
            {
                var studentViewModel = new StudentAttendance
                {
                    Id = record.Id,
                    StudentId = student.StudentId,
                    ClassId = student.ClassId,
                    RollNo = student.StudentRollNo,
                    SubjectId = subjectId,
                    ClassName = student.Class.ClassName,
                    SubjectName = db.subjets.FirstOrDefault(s => s.SubjectId == subjectId)?.SubjectName,
                    StudentName = student.StudentName,
                    IsAttendanceMarked = true, // For individual student view, assume all records are marked
                    Date = record.Date, // Populate Date
                    Remarks = record.Remarks // Populate Remarks
                };

                // Add the studentViewModel to the list
                viewModel.Add(studentViewModel);
            }

            // Step 5: Return the view with the populated ViewModel
            return View(viewModel);
        }


    }
}
