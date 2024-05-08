using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models.Admin;
using School_Management_System.Models.Teacher;

namespace School_Management_System.Controllers.Parents
{
    public class ParentDashboardController : Controller
    {
        private readonly ApplicationDbContext db;

        public ParentDashboardController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAllStudents()
        {
            // Step 1: Retrieve the parent's email from the session
            var parentEmail = HttpContext.Session.GetString("ParentEmail");

            if (string.IsNullOrEmpty(parentEmail))
            {
                // Handle the case when the parent email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the parent in the database
            var parent = db.Parents.FirstOrDefault(p => p.ParentEmail == parentEmail);

            if (parent == null)
            {
                // Handle the case when the parent is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            var parentFromDb=db.Parents.Where(s=>s.ParentEmail == parentEmail).ToList();
            // Step 4: Return the list of students to the view
            return View(parentFromDb);
        }

        public IActionResult ViewFees()
        {
            List<Fees> objList = new List<Fees>();
            var feesList = db.fees.Include(f => f.Class).ToList();
            return View(feesList);
        }

        public IActionResult ViewMarks()
        {
            // Step 1: Retrieve the parent's email from the session
            var parentEmail = HttpContext.Session.GetString("ParentEmail");

            if (string.IsNullOrEmpty(parentEmail))
            {
                // Handle the case when the parent email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the parent in the database
            var parent = db.Parents.FirstOrDefault(p => p.ParentEmail == parentEmail);

            if (parent == null)
            {
                // Handle the case when the parent is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            var parentFromDb = db.Parents.Where(s => s.ParentEmail == parentEmail).ToList();
            // Step 4: Return the list of students to the view
            return View(parentFromDb);
        }

        public IActionResult ViewSubjectsMarks(int classId,int studentId)
        {
            
            List<Subjects> objList = new List<Subjects>();

            // Fetch only students belonging to the selected class
            var stdList = db.subjets.Include(f => f.Class)
                                     .Where(s => s.ClassId == classId)
                                     .ToList();

            HttpContext.Session.SetInt32("StudentId", studentId);
            return View(stdList);
        }


        public IActionResult ViewIndividualStudentMarks(int classId, int subjectId, int studentId)
        {
            studentId= (int)HttpContext.Session.GetInt32("StudentId");
            // Step 1: Retrieve the student's information
            var student = db.students.Include(sa => sa.Class)
                .FirstOrDefault(sa => sa.ClassId == classId && sa.StudentId == studentId);

            if (student == null)
            {
                // Handle the case when the student is not found
                return RedirectToAction("Error", "Home");
            }

            var studentMarks = db.Mark.FirstOrDefault(sa =>
                    sa.StudentId == student.StudentId &&
                    sa.SubjectId == subjectId &&
                    sa.ClassId == classId);

            // Step 2: Retrieve all attendance records for the specified student, class, and subject
            var marksRecords = db.Mark
                .Where(sa => sa.ClassId == classId && sa.SubjectId == subjectId && sa.StudentId == studentId)
                .ToList();

            // Step 3: Create a ViewModel to represent the student's attendance records
            var viewModel = new List<Marks>();

            // Step 4: Populate the ViewModel with attendance records
            foreach (var record in marksRecords)
            {
                var markViewModel = new Marks
                {
                    StudentId = studentId,
                    ClassId = classId,
                    RollNo = student.StudentRollNo,
                    SubjectId = subjectId,
                    ClassName = student.Class.ClassName,
                    SubjectName = db.subjets.FirstOrDefault(s => s.SubjectId == subjectId)?.SubjectName,
                    StudentName = student.StudentName,
                    IsMarked = true, // For individual student view, assume all records are marked
                    Date = record.Date, // Populate Date
                    TestName = record.TestName,
                    TotalMarks = record.TotalMarks,
                    ObtainedMarks = record.ObtainedMarks,
                    Id = record.Id,
                };

                // Add the studentViewModel to the list
                viewModel.Add(markViewModel);
            }

            // Step 5: Return the view with the populated ViewModel
            return View(viewModel);
        }

        public IActionResult ViewAttendance()
        {
            // Step 1: Retrieve the parent's email from the session
            var parentEmail = HttpContext.Session.GetString("ParentEmail");

            if (string.IsNullOrEmpty(parentEmail))
            {
                // Handle the case when the parent email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the parent in the database
            var parent = db.Parents.FirstOrDefault(p => p.ParentEmail == parentEmail);

            if (parent == null)
            {
                // Handle the case when the parent is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            var parentFromDb = db.Parents.Where(s => s.ParentEmail == parentEmail).ToList();
            // Step 4: Return the list of students to the view
            return View(parentFromDb);
        }

        public IActionResult ViewSubjectsAttendance(int classId, int studentId)
        {

            List<Subjects> objList = new List<Subjects>();

            // Fetch only students belonging to the selected class
            var stdList = db.subjets.Include(f => f.Class)
                                     .Where(s => s.ClassId == classId)
                                     .ToList();

            HttpContext.Session.SetInt32("StudentId", studentId);
            return View(stdList);
        }

        public IActionResult ViewIndividualStudentAttendance(int classId, int subjectId, int studentId)
        {
            studentId = (int)HttpContext.Session.GetInt32("StudentId");
            // Step 1: Retrieve the student's information
            var student = db.students.Include(sa => sa.Class)
                .FirstOrDefault(sa => sa.ClassId == classId && sa.StudentId == studentId);

            if (student == null)
            {
                // Handle the case when the student is not found
                return RedirectToAction("Error", "Home");
            }

            var studentAttendance = db.StudentAttendances.FirstOrDefault(sa =>
                    sa.StudentId == student.StudentId &&
                    sa.SubjectId == subjectId &&
                    sa.ClassId == classId);

            // Step 2: Retrieve all attendance records for the specified student, class, and subject
            var attendanceRecords = db.StudentAttendances
                .Where(sa => sa.ClassId == classId && sa.SubjectId == subjectId && sa.StudentId == studentId)
                .ToList();

            // Step 3: Create a ViewModel to represent the student's attendance records
            var viewModel = new List<StudentAttendance>();

            // Step 4: Populate the ViewModel with attendance records
            foreach (var record in attendanceRecords)
            {
                var markViewModel = new StudentAttendance
                {
                    StudentId = studentId,
                    ClassId = classId,
                    RollNo = student.StudentRollNo,
                    SubjectId = subjectId,
                    ClassName = student.Class.ClassName,
                    SubjectName = db.subjets.FirstOrDefault(s => s.SubjectId == subjectId)?.SubjectName,
                    StudentName = student.StudentName,
                    IsAttendanceMarked = true, // For individual student view, assume all records are marked
                    Date = record.Date, // Populate Date
                    Id = record.Id,
                    Remarks= record.Remarks,
                };

                // Add the studentViewModel to the list
                viewModel.Add(markViewModel);
            }

            // Step 5: Return the view with the populated ViewModel
            return View(viewModel);
        }
    }
}
