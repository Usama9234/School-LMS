using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using NuGet.DependencyResolver;
using School_Management_System.Data;
using School_Management_System.Models.Admin;
using School_Management_System.Models.Teacher;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace School_Management_System.Controllers.Teacher
{
    public class TeacherDashboardController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly IWebHostEnvironment _environment;

        public TeacherDashboardController(ApplicationDbContext _db,IWebHostEnvironment he)
        {
            db = _db;
            _environment = he;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAllAssignedSubjects()
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Once you have the teacher, use their TeacherId to find the assigned subjects
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Include(a => a.Subject.Class) // Assuming there is a navigation property from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId)
                .ToList();

            // Step 4: Retrieve the unique class names from the assigned subjects
            var uniqueClassNames = assignedSubjects.Select(a => a.Subject.Class.ClassName).Distinct().ToList();

            // Step 5: Create a ViewModel to represent the details
            var viewModel = new List<AssignedSubjects>(); // You may want to create a dedicated ViewModel for better organization

            foreach (var uniqueClassName in uniqueClassNames)
            {
                // For each unique class name, find the associated assigned subject (you might want to adjust this logic based on your requirements)
                var assignedSubject = assignedSubjects.FirstOrDefault(a => a.Subject.Class.ClassName == uniqueClassName);

                if (assignedSubject != null)
                {
                    var assignedSubjectViewModel = new AssignedSubjects
                    {
                        AssignedSubjectId = assignedSubject.AssignedSubjectId,
                        SubjectId = assignedSubject.SubjectId,
                        TeacherId = assignedSubject.TeacherId,
                        ClassId = assignedSubject.Subject.Class.ClassId,
                        Subject = assignedSubject.Subject,
                        SubjectList = assignedSubject.SubjectList,
                        TeachersList = assignedSubject.TeachersList,
                        ClassesList = assignedSubject.ClassesList,
                        SubjectName = assignedSubject.Subject.SubjectName,
                        Teachername = assignedSubject.Teachername,
                        ClassName = assignedSubject.Subject.Class.ClassName
                    };

                    viewModel.Add(assignedSubjectViewModel);
                }
            }

            return View(viewModel);
        }


        public IActionResult ViewAssignedSubjects(int classId)
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve the assigned subjects for the specified class and teacher
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Include(a => a.Subject.Class) // Assuming there is a navigation property from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId && a.ClassId == classId)
                .ToList();

            // Step 4: Create a ViewModel to represent the details
            var viewModel = new List<AssignedSubjects>(); // Create a dedicated ViewModel for better organization

            foreach (var assignedSubject in assignedSubjects)
            {
                var assignedSubjectViewModel = new AssignedSubjects
                {
                    AssignedSubjectId = assignedSubject.AssignedSubjectId,
                    SubjectId = assignedSubject.SubjectId,
                    TeacherId = assignedSubject.TeacherId,
                    ClassId = assignedSubject.Subject.Class.ClassId,
                    SubjectName = assignedSubject.Subject.SubjectName,
                    Teachername = assignedSubject.Teachername,
                    ClassName = assignedSubject.Subject.Class.ClassName
                };

                viewModel.Add(assignedSubjectViewModel);
            }

            // You can pass the viewModel to the view or process it accordingly
            return View(viewModel);
        }


        public IActionResult ViewAllStudents()
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Once you have the teacher, use their TeacherId to find the assigned subjects
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Include(a => a.Subject.Class) // Assuming there is a navigation property from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId)
                .ToList();

            // Step 4: Retrieve the unique class names from the assigned subjects
            var uniqueClassNames = assignedSubjects.Select(a => a.Subject.Class.ClassName).Distinct().ToList();

            // Step 5: Create a ViewModel to represent the details
            var viewModel = new List<AssignedSubjects>(); // You may want to create a dedicated ViewModel for better organization

            foreach (var uniqueClassName in uniqueClassNames)
            {
                // For each unique class name, find the associated assigned subject (you might want to adjust this logic based on your requirements)
                var assignedSubject = assignedSubjects.FirstOrDefault(a => a.Subject.Class.ClassName == uniqueClassName);

                if (assignedSubject != null)
                {
                    var assignedSubjectViewModel = new AssignedSubjects
                    {
                        AssignedSubjectId = assignedSubject.AssignedSubjectId,
                        SubjectId = assignedSubject.SubjectId,
                        TeacherId = assignedSubject.TeacherId,
                        ClassId = assignedSubject.Subject.Class.ClassId,
                        Subject = assignedSubject.Subject,
                        SubjectList = assignedSubject.SubjectList,
                        TeachersList = assignedSubject.TeachersList,
                        ClassesList = assignedSubject.ClassesList,
                        SubjectName = assignedSubject.Subject.SubjectName,
                        Teachername = assignedSubject.Teachername,
                        ClassName = assignedSubject.Subject.Class.ClassName
                    };

                    viewModel.Add(assignedSubjectViewModel);
                }
            }

            return View(viewModel);
        }

        public IActionResult ViewStudents(int classId)
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve the students of the specified class
            var studentsOfClass = db.students.Where(s => s.ClassId == classId) // Assuming there is a property ClassId in the Student model
                .ToList();

            // Step 4: Create a ViewModel to represent the student details
            var viewModel = new List<StudentDetails>(); // You may want to create a dedicated ViewModel for better organization

            foreach (var student in studentsOfClass)
            {
                var studentViewModel = new StudentDetails
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    StudentRollNo = student.StudentRollNo

                    // Add other properties as needed
                };

                viewModel.Add(studentViewModel);
            }

            return View(viewModel);
        }


        public IActionResult MarkAttendance()
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Once you have the teacher, use their TeacherId to find the assigned subjects
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Include(a => a.Subject.Class) // Assuming there is a navigation property from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId)
                .ToList();

            // Step 4: Retrieve the unique class names from the assigned subjects
            var uniqueClassNames = assignedSubjects.Select(a => a.Subject.Class.ClassName).Distinct().ToList();

            // Step 5: Create a ViewModel to represent the details
            var viewModel = new List<AssignedSubjects>(); // You may want to create a dedicated ViewModel for better organization

            foreach (var uniqueClassName in uniqueClassNames)
            {
                // For each unique class name, find the associated assigned subject (you might want to adjust this logic based on your requirements)
                var assignedSubject = assignedSubjects.FirstOrDefault(a => a.Subject.Class.ClassName == uniqueClassName);

                if (assignedSubject != null)
                {
                    var assignedSubjectViewModel = new AssignedSubjects
                    {
                        AssignedSubjectId = assignedSubject.AssignedSubjectId,
                        SubjectId = assignedSubject.SubjectId,
                        TeacherId = assignedSubject.TeacherId,
                        ClassId = assignedSubject.Subject.Class.ClassId,
                        Subject = assignedSubject.Subject,
                        SubjectList = assignedSubject.SubjectList,
                        TeachersList = assignedSubject.TeachersList,
                        ClassesList = assignedSubject.ClassesList,
                        SubjectName = assignedSubject.Subject.SubjectName,
                        Teachername = assignedSubject.Teachername,
                        ClassName = assignedSubject.Subject.Class.ClassName
                    };

                    viewModel.Add(assignedSubjectViewModel);
                }
            }

            return View(viewModel);
        }


        public IActionResult MarkClassAttendance(int classId)
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve the assigned subjects for the specified class and teacher
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Include(a => a.Subject.Class) // Assuming there is a navigation property from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId && a.ClassId == classId)
                .ToList();

            // Step 4: Create a ViewModel to represent the details
            var viewModel = new List<AssignedSubjects>(); // Create a dedicated ViewModel for better organization

            foreach (var assignedSubject in assignedSubjects)
            {
                var assignedSubjectViewModel = new AssignedSubjects
                {
                    AssignedSubjectId = assignedSubject.AssignedSubjectId,
                    SubjectId = assignedSubject.SubjectId,
                    TeacherId = assignedSubject.TeacherId,
                    ClassId = assignedSubject.Subject.Class.ClassId,
                    SubjectName = assignedSubject.Subject.SubjectName,
                    Teachername = assignedSubject.Teachername,
                    ClassName = assignedSubject.Subject.Class.ClassName
                };

                viewModel.Add(assignedSubjectViewModel);
            }

            // You can pass the viewModel to the view or process it accordingly
            return View(viewModel);
        }

        public IActionResult MarkStudentAttendance(int classId, int subjectId)
        {
            var studentsOfClass = db.students.Include(sa => sa.Class)
                .Where(sa => sa.ClassId == classId).ToList();

            // Step 3: Create a ViewModel to represent the student details
            var viewModel = new List<StudentAttendance>();

            var today = DateOnly.FromDateTime(DateTime.Today); // Get today's date as a DateOnly object

            foreach (var student in studentsOfClass)
            {
                var studentAttendance = db.StudentAttendances.FirstOrDefault(sa =>
                    sa.StudentId == student.StudentId &&
                    sa.SubjectId == subjectId &&
                    sa.ClassId == classId &&
                    sa.Date == today); // Check if a record for the student on the given date exists

                bool isAttendanceMarked = studentAttendance != null;

                var studentViewModel = new StudentAttendance
                {
                    Id = studentAttendance != null ? studentAttendance.Id : 0,
                    StudentId = student.StudentId,
                    ClassId = student.ClassId,
                    RollNo = student.StudentRollNo,
                    SubjectId = subjectId,
                    ClassName = student.Class.ClassName,
                    SubjectName = db.subjets.FirstOrDefault(s => s.SubjectId == subjectId)?.SubjectName, // Fetch subject name from database
                    StudentName = student.StudentName,
                    IsAttendanceMarked = isAttendanceMarked, // Flag indicating if attendance is already marked for the student on the given dat
                };
                viewModel.Add(studentViewModel);
            }

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult MarkStudentAttendance(StudentAttendance model)
        {
            // Step 1: Retrieve today's date
            var today = DateOnly.FromDateTime(DateTime.Today);

            // Step 2: Retrieve students of the specified class
            var studentsOfClass = db.students
                .Where(sa => sa.ClassId == model.ClassId)
                .Select(sa => new
                {
                    sa.StudentId,
                    sa.StudentRollNo,
                    sa.StudentName,
                    ClassName = sa.Class.ClassName
                })
                .ToList();

            // Step 3: Create a ViewModel to represent the student details
            var viewModel = studentsOfClass.Select(student => new StudentAttendance
            {
                StudentId = student.StudentId,
                ClassId = model.ClassId,
                RollNo = student.StudentRollNo,
                SubjectId = model.SubjectId,
                ClassName = student.ClassName,
                SubjectName = db.subjets.FirstOrDefault(s => s.SubjectId == model.SubjectId)?.SubjectName,
                StudentName = student.StudentName,
                IsAttendanceMarked = db.StudentAttendances
                    .Any(sa => sa.StudentId == student.StudentId &&
                               sa.SubjectId == model.SubjectId &&
                               sa.ClassId == model.ClassId &&
                               sa.Date == today)
            }).ToList();

            // Step 4: Check if remarks are not null
            if (!string.IsNullOrEmpty(model.Remarks))
            {
                // Create a new instance of StudentAttendance and populate its properties
                var studentAttendance = new StudentAttendance
                {
                    StudentId = model.StudentId,
                    SubjectId = model.SubjectId,
                    ClassId = model.ClassId,
                    Date = today,
                    Remarks = model.Remarks,
                    RollNo = model.RollNo,
                    ClassName = model.ClassName,
                    SubjectName = model.SubjectName,
                    StudentName = model.StudentName,
                };

                // Save to database
                db.StudentAttendances.Add(studentAttendance);
                db.SaveChanges(); // Save changes to the database

                // Set success message in TempData
                TempData["success"] = "Attendance marked successfully.";

                // Redirect to the action method with classId and subjectId
                return RedirectToAction("MarkStudentAttendance", "TeacherDashboard", new { classId = model.ClassId, subjectId = model.SubjectId });
            }

            // If remarks are null, display an error message and return the view with the viewModel
            TempData["error"] = "Remarks cannot be empty.";
            return View(viewModel);
        }


        public IActionResult ViewAttendance()
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Once you have the teacher, use their TeacherId to find the assigned subjects
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Include(a => a.Subject.Class) // Assuming there is a navigation property from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId)
                .ToList();

            // Step 4: Retrieve the unique class names from the assigned subjects
            var uniqueClassNames = assignedSubjects.Select(a => a.Subject.Class.ClassName).Distinct().ToList();

            // Step 5: Create a ViewModel to represent the details
            var viewModel = new List<AssignedSubjects>(); // You may want to create a dedicated ViewModel for better organization

            foreach (var uniqueClassName in uniqueClassNames)
            {
                // For each unique class name, find the associated assigned subject (you might want to adjust this logic based on your requirements)
                var assignedSubject = assignedSubjects.FirstOrDefault(a => a.Subject.Class.ClassName == uniqueClassName);

                if (assignedSubject != null)
                {
                    var assignedSubjectViewModel = new AssignedSubjects
                    {
                        AssignedSubjectId = assignedSubject.AssignedSubjectId,
                        SubjectId = assignedSubject.SubjectId,
                        TeacherId = assignedSubject.TeacherId,
                        ClassId = assignedSubject.Subject.Class.ClassId,
                        Subject = assignedSubject.Subject,
                        SubjectList = assignedSubject.SubjectList,
                        TeachersList = assignedSubject.TeachersList,
                        ClassesList = assignedSubject.ClassesList,
                        SubjectName = assignedSubject.Subject.SubjectName,
                        Teachername = assignedSubject.Teachername,
                        ClassName = assignedSubject.Subject.Class.ClassName
                    };

                    viewModel.Add(assignedSubjectViewModel);
                }
            }

            return View(viewModel);
        }

        public IActionResult ViewClassAttendance(int classId)
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve the assigned subjects for the specified class and teacher
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Include(a => a.Subject.Class) // Assuming there is a navigation property from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId && a.ClassId == classId)
                .ToList();

            // Step 4: Create a ViewModel to represent the details
            var viewModel = new List<AssignedSubjects>(); // Create a dedicated ViewModel for better organization

            foreach (var assignedSubject in assignedSubjects)
            {
                var assignedSubjectViewModel = new AssignedSubjects
                {
                    AssignedSubjectId = assignedSubject.AssignedSubjectId,
                    SubjectId = assignedSubject.SubjectId,
                    TeacherId = assignedSubject.TeacherId,
                    ClassId = assignedSubject.Subject.Class.ClassId,
                    SubjectName = assignedSubject.Subject.SubjectName,
                    Teachername = assignedSubject.Teachername,
                    ClassName = assignedSubject.Subject.Class.ClassName
                };

                viewModel.Add(assignedSubjectViewModel);
            }

            // You can pass the viewModel to the view or process it accordingly
            return View(viewModel);
        }


        public IActionResult ViewStudentAttendance(int classId, int subjectId)
        {
            var studentsOfClass = db.students.Include(sa => sa.Class)
                .Where(sa => sa.ClassId == classId).ToList();

            // Step 3: Create a ViewModel to represent the student details
            var viewModel = new List<StudentAttendance>();

            var today = DateOnly.FromDateTime(DateTime.Today); // Get today's date as a DateOnly object

            foreach (var student in studentsOfClass)
            {
                var studentAttendance = db.StudentAttendances.FirstOrDefault(sa =>
                    sa.StudentId == student.StudentId &&
                    sa.SubjectId == subjectId &&
                    sa.ClassId == classId &&
                    sa.Date == today); // Check if a record for the student on the given date exists

                bool isAttendanceMarked = studentAttendance != null;

                var studentViewModel = new StudentAttendance
                {
                    Id = studentAttendance != null ? studentAttendance.Id : 0,
                    StudentId = student.StudentId,
                    ClassId = student.ClassId,
                    RollNo = student.StudentRollNo,
                    SubjectId = subjectId,
                    ClassName = student.Class.ClassName,
                    SubjectName = db.subjets.FirstOrDefault(s => s.SubjectId == subjectId)?.SubjectName, // Fetch subject name from database
                    StudentName = student.StudentName,
                    IsAttendanceMarked = isAttendanceMarked // Flag indicating if attendance is already marked for the student on the given date
                };
                viewModel.Add(studentViewModel);
            }

            return View(viewModel);
        }

        public IActionResult ViewIndividualStudent(int classId, int subjectId, int studentId)
        {
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
                var studentViewModel = new StudentAttendance
                {
                    Id = studentAttendance != null ? studentAttendance.Id : 0,
                    StudentId = studentId,
                    ClassId = classId,
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


        public IActionResult EditStudentAttendance(int id)
        {
            // Step 1: Retrieve the StudentAttendance record from the database based on the provided id
            var studentAttendance = db.StudentAttendances.FirstOrDefault(sa => sa.Id == id);

            if (studentAttendance == null)
            {
                // Handle the case when the StudentAttendance record is not found
                return RedirectToAction("Error", "Home");
            }

            // Step 2: Populate a ViewModel with the retrieved StudentAttendance record
            var viewModel = new StudentAttendance
            {
                Id = studentAttendance.Id,
                StudentId = studentAttendance.StudentId,
                SubjectId = studentAttendance.SubjectId,
                ClassId = studentAttendance.ClassId,
                Date = studentAttendance.Date,
                Remarks = studentAttendance.Remarks,
                ClassName=studentAttendance.ClassName,
                SubjectName = studentAttendance.SubjectName,
                StudentName = studentAttendance.StudentName,
                RollNo = studentAttendance.RollNo,
                // Add other properties as needed
            };

            // Step 3: Return the view with the populated ViewModel
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditStudentAttendance(StudentAttendance model, int classId, int subjectId, int studentId)
        {
            // Step 1: Retrieve the StudentAttendance record from the database based on the provided id
            var studentAttendance = db.StudentAttendances.FirstOrDefault(sa => sa.Id == model.Id);

            if (studentAttendance == null)
            {
                // Handle the case when the StudentAttendance record is not found
                return RedirectToAction("Error", "Home");
            }

            // Step 2: Populate a ViewModel with the retrieved StudentAttendance record
            var viewModel = new StudentAttendance
            {
                Id = studentAttendance.Id,
                StudentId = studentAttendance.StudentId,
                SubjectId = studentAttendance.SubjectId,
                ClassId = studentAttendance.ClassId,
                Date = studentAttendance.Date,
                Remarks = studentAttendance.Remarks,
                ClassName = studentAttendance.ClassName,
                SubjectName = studentAttendance.SubjectName,
                StudentName = studentAttendance.StudentName,
                RollNo = studentAttendance.RollNo,
                // Add other properties as needed
            };

            if (!string.IsNullOrEmpty(model.Remarks))
            {
                var studentAttendance1 = db.StudentAttendances.FirstOrDefault(sa => sa.Id == model.Id);

                if (studentAttendance1 == null)
                {
                    // If the record is not found, set an error message and redirect to the dashboard
                    TempData["ErrorMessage"] = "Student attendance record not found.";
                    return RedirectToAction("MarkStudentAttendance", "TeacherDashboard");
                }

                try
                {
                    // Update the student attendance record with the new values from the model
                    studentAttendance1.Date = model.Date;
                    studentAttendance1.Remarks = model.Remarks;

                    // Save the changes to the database
                    db.SaveChanges();

                    // Set a success message and redirect to the dashboard
                    TempData["success"] = "Student attendance updated successfully.";

                    return RedirectToAction("ViewIndividualStudent", "TeacherDashboard", new { classId , subjectId,studentId});
                }
                catch (Exception ex)
                {
                    // Handle any potential errors and display an error message
                    //TempData["ErrorMessage"] = "An error occurred while updating student attendance.";
                    // Log the exception if needed
                    return RedirectToAction("ViewIndividualStudent", "TeacherDashboard", new { classId, subjectId, studentId });
                }
            }

            // If the model state is not valid, return the view with the model to display validation errors
            return View(viewModel);
        }


        public IActionResult UploadMaterial()
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Once you have the teacher, use their TeacherId to find the assigned subjects
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject.Class) // Assuming there are navigation properties from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId)
                .ToList();

            // Step 4: Retrieve the unique class ids from the assigned subjects
            var uniqueClassIds = assignedSubjects.Select(a => a.Subject.ClassId).Distinct().ToList();

            // Step 5: Retrieve the list of classes based on the unique class ids
            var classesList = db.Class.Where(c => uniqueClassIds.Contains(c.ClassId)).ToList();

            // Step 6: Create a view model and populate it with both lists
            var viewModel = new LearningMaterial
            {
                AssignedSubjectList = assignedSubjects,
                ClassesList = classesList
            };

            return View(viewModel);
        }

        public IActionResult GetAssignedSubjects(int classId)
        {
            // Retrieve assigned subjects for the specified class and teacher
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return Json(new { success = false, message = "Teacher not found." });
            }

            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Where(a => a.Subject.ClassId == classId && a.TeacherId == teacher.TeacherId)
                .Select(a => new { a.SubjectId, a.Subject.SubjectName })
                .ToList();

            return Json(assignedSubjects);
        }


        [HttpPost]
        public async Task<IActionResult> UploadMaterial(LearningMaterial learningMaterial, IFormFile file)
        {
            ModelState.Remove("ClassId");
            ModelState.Remove("SubjectId");
            ModelState.Remove("Class");
            ModelState.Remove("Subject");
            ModelState.Remove("ClassesList");
            ModelState.Remove("AssignedSubjectList");
            ModelState.Remove("ClassName");
            ModelState.Remove("FileName");
            ModelState.Remove("FilePath");
            ModelState.Remove("FileType");
            ModelState.Remove("SizeBytes");

            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Once you have the teacher, use their TeacherId to find the assigned subjects
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject.Class) // Assuming there are navigation properties from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId)
                .ToList();

            // Step 4: Retrieve the unique class ids from the assigned subjects
            var uniqueClassIds = assignedSubjects.Select(a => a.Subject.ClassId).Distinct().ToList();

            // Step 5: Retrieve the list of classes based on the unique class ids
            var classesList = db.Class.Where(c => uniqueClassIds.Contains(c.ClassId)).ToList();

            // Step 6: Create a view model and populate it with both lists
            var viewModel = new LearningMaterial
            {
                AssignedSubjectList = assignedSubjects,
                ClassesList = classesList
            };


            if (ModelState.IsValid)
            {
                if (learningMaterial.ClassId <= 0)
                {
                    TempData["error"] = "Class Not Selected";
                    return View(viewModel);
                }
                if (learningMaterial.SubjectId <= 0)
                {
                    TempData["error"] = "Subject Not Selected";
                    return View(viewModel);
                }

                if (file == null || file.Length == 0)
                    return BadRequest("No file uploaded.");

                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Step 7: Retrieve ClassName and SubjectName based on ClassId and SubjectId
                var className = db.Class.FirstOrDefault(c => c.ClassId == learningMaterial.ClassId)?.ClassName;
                var subjectName = db.subjets.FirstOrDefault(s => s.SubjectId == learningMaterial.SubjectId)?.SubjectName;
                
                var model = new LearningMaterial
                {
                    FileName = fileName,
                    FilePath = filePath,
                    FileType = Path.GetExtension(file.FileName),
                    SizeBytes = file.Length,
                    Title = learningMaterial.Title,
                    ClassId = learningMaterial.ClassId,
                    SubjectId = learningMaterial.SubjectId,
                    UploadDate = DateTime.Now,
                    ClassName = className, // Assign ClassName retrieved from the database
                    SubjectName = subjectName, // Assign SubjectName retrieved from the database
                };

                db.LearningMaterials.Add(model);
                await db.SaveChangesAsync();
                TempData["success"] = "Uploaded Succesfully";
                return RedirectToAction("ViewUploadedMaterials");
            }

            TempData["error"] = "File Not Selected";
            return View(viewModel);

        }


        public IActionResult ViewUploadedMaterials()
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve the learning materials along with their subjects and classes
            var learningMaterials = db.LearningMaterials
                .Include(lm => lm.Subject)
                .Include(lm => lm.Subject.Class)
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

        
        public IActionResult DeleteMaterial(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            LearningMaterial? categoryFromDb = db.LearningMaterials.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("DeleteMaterial")]
        public async Task<IActionResult> DeleteMaterials(int id)
        {
            var learningMaterial = await db.LearningMaterials.FindAsync(id);
            if (learningMaterial == null)
                return NotFound();

            // Delete the file from the uploads folder
            var filePath = learningMaterial.FilePath;
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            // Remove the learning material from the database
            db.LearningMaterials.Remove(learningMaterial);
            await db.SaveChangesAsync();

            TempData["success"] = "Material deleted successfully";
            return RedirectToAction("ViewUploadedMaterials"); // Redirect to the appropriate action/method after deletion
        }

        public IActionResult EditMaterial(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            LearningMaterial? categoryFromDb = db.LearningMaterials.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [HttpPost]
        public async Task<IActionResult> EditMaterial(int id, [Bind("Id,Title")] LearningMaterial model, IFormFile file)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            ModelState.Remove("ClassId");
            ModelState.Remove("SubjectId");
            ModelState.Remove("Class");
            ModelState.Remove("Subject");
            ModelState.Remove("ClassesList");
            ModelState.Remove("AssignedSubjectList");
            ModelState.Remove("ClassName");
            ModelState.Remove("FileName");
            ModelState.Remove("FilePath");
            ModelState.Remove("FileType");
            ModelState.Remove("SizeBytes");


            if (ModelState.IsValid)
            {
                try
                {
                    var material = await db.LearningMaterials.FindAsync(id);

                    if (material == null)
                    {
                        return NotFound();
                    }

                    // Update the title
                    material.Title = model.Title;
                    material.UploadDate = DateTime.Now;

                    // Update the file if a new one is provided
                    if (file != null && file.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);

                        // Delete the previous file if needed
                        if (System.IO.File.Exists(material.FilePath))
                        {
                            System.IO.File.Delete(material.FilePath);
                        }

                        // Save the new file
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        material.FileName = fileName;
                        material.FilePath = filePath;
                        material.FileType = Path.GetExtension(file.FileName);
                        material.SizeBytes = file.Length;
                    }

                    db.Update(material);
                    await db.SaveChangesAsync();
                    TempData["success"] = "Material updated successfully";

                    return RedirectToAction("ViewUploadedMaterials"); // Redirect to a suitable action after editing
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            }
            TempData["error"] = "File Not Selected";
            // If ModelState is not valid, return to the edit view with the model
            return RedirectToAction("EditMaterial", new { id = model.Id });
        }

        public IActionResult ManageMarks()
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Once you have the teacher, use their TeacherId to find the assigned subjects
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Include(a => a.Subject.Class) // Assuming there is a navigation property from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId)
                .ToList();

            // Step 4: Retrieve the unique class names from the assigned subjects
            var uniqueClassNames = assignedSubjects.Select(a => a.Subject.Class.ClassName).Distinct().ToList();

            // Step 5: Create a ViewModel to represent the details
            var viewModel = new List<AssignedSubjects>(); // You may want to create a dedicated ViewModel for better organization

            foreach (var uniqueClassName in uniqueClassNames)
            {
                // For each unique class name, find the associated assigned subject (you might want to adjust this logic based on your requirements)
                var assignedSubject = assignedSubjects.FirstOrDefault(a => a.Subject.Class.ClassName == uniqueClassName);

                if (assignedSubject != null)
                {
                    var assignedSubjectViewModel = new AssignedSubjects
                    {
                        AssignedSubjectId = assignedSubject.AssignedSubjectId,
                        SubjectId = assignedSubject.SubjectId,
                        TeacherId = assignedSubject.TeacherId,
                        ClassId = assignedSubject.Subject.Class.ClassId,
                        Subject = assignedSubject.Subject,
                        SubjectList = assignedSubject.SubjectList,
                        TeachersList = assignedSubject.TeachersList,
                        ClassesList = assignedSubject.ClassesList,
                        SubjectName = assignedSubject.Subject.SubjectName,
                        Teachername = assignedSubject.Teachername,
                        ClassName = assignedSubject.Subject.Class.ClassName
                    };

                    viewModel.Add(assignedSubjectViewModel);
                }
            }

            return View(viewModel);
        }

        public IActionResult ManageClassMarks(int classId)
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve the assigned subjects for the specified class and teacher
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Include(a => a.Subject.Class) // Assuming there is a navigation property from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId && a.ClassId == classId)
                .ToList();

            // Step 4: Create a ViewModel to represent the details
            var viewModel = new List<AssignedSubjects>(); // Create a dedicated ViewModel for better organization

            foreach (var assignedSubject in assignedSubjects)
            {
                var assignedSubjectViewModel = new AssignedSubjects
                {
                    AssignedSubjectId = assignedSubject.AssignedSubjectId,
                    SubjectId = assignedSubject.SubjectId,
                    TeacherId = assignedSubject.TeacherId,
                    ClassId = assignedSubject.Subject.Class.ClassId,
                    SubjectName = assignedSubject.Subject.SubjectName,
                    Teachername = assignedSubject.Teachername,
                    ClassName = assignedSubject.Subject.Class.ClassName
                };

                viewModel.Add(assignedSubjectViewModel);
            }

            // You can pass the viewModel to the view or process it accordingly
            return View(viewModel);
        }


        public IActionResult MarkStudentMarks(int classId, int subjectId)
        {
            var studentsOfClass = db.students.Include(sa => sa.Class)
                .Where(sa => sa.ClassId == classId).ToList();

            // Step 3: Create a ViewModel to represent the student details
            var viewModel = new List<Marks>();

            var today = DateOnly.FromDateTime(DateTime.Today); // Get today's date as a DateOnly object

            foreach (var student in studentsOfClass)
            {
                var studentAttendance = db.Mark.FirstOrDefault(sa =>
                    sa.StudentId == student.StudentId &&
                    sa.SubjectId == subjectId &&
                    sa.ClassId == classId &&
                    sa.Date == today); // Check if a record for the student on the given date exists

                bool isAttendanceMarked = studentAttendance != null;

                var markViewModel = new Marks
                {
                    Id = studentAttendance != null ? studentAttendance.Id : 0,
                    StudentId = student.StudentId,
                    ClassId = student.ClassId,
                    RollNo = student.StudentRollNo,
                    SubjectId = subjectId,
                    ClassName = student.Class.ClassName,
                    SubjectName = db.subjets.FirstOrDefault(s => s.SubjectId == subjectId)?.SubjectName, // Fetch subject name from database
                    StudentName = student.StudentName,
                    IsMarked = isAttendanceMarked, // Flag indicating if attendance is already marked for the student on the given dat
                    

                };
                viewModel.Add(markViewModel);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MarkStudentMarks(Marks model)
        {
            // Step 1: Retrieve today's date
            var today = DateOnly.FromDateTime(DateTime.Today);

            // Step 2: Retrieve students of the specified class
            var studentsOfClass = db.students
                .Where(sa => sa.ClassId == model.ClassId)
                .Select(sa => new
                {
                    sa.StudentId,
                    sa.StudentRollNo,
                    sa.StudentName,
                    sa.Class.ClassName
                })
                .ToList();

            // Step 3: Create a ViewModel to represent the student details
            var viewModel = studentsOfClass.Select(student => new Marks
            {
                StudentId = student.StudentId,
                ClassId = model.ClassId,
                RollNo = student.StudentRollNo,
                SubjectId = model.SubjectId,
                ClassName = student.ClassName,
                //SubjectName = db.subjets.FirstOrDefault(s => s.SubjectId == model.SubjectId)?.SubjectName,
                SubjectName=model.SubjectName,
                StudentName = student.StudentName,
                IsMarked = db.Mark
        .Any(sa => sa.StudentId == student.StudentId &&
                   sa.SubjectId == model.SubjectId &&
                   sa.ClassId == model.ClassId &&
                   sa.Id == model.Id)
            }).ToList();

            // Step 4: Check if Test Name are not null
           /* if (!string.IsNullOrEmpty(model.TestName) && model.TotalMarks != null && model.ObtainedMarks != null)
            {*/
                // Check if obtained marks and total marks are not negative
                if (model.TotalMarks >= 0 && model.ObtainedMarks >= 0)
                {
                    // Check if obtained marks are less than or equal to total marks
                    if (model.ObtainedMarks <= model.TotalMarks)
                    {
                        // Create a new instance of StudentAttendance and populate its properties
                        var studentMark = new Marks
                        {
                            Id=model.Id,
                            StudentId = model.StudentId,
                            SubjectId = model.SubjectId,
                            ClassId = model.ClassId,
                            Date = today,
                            TestName = model.TestName,
                            RollNo = model.RollNo,
                            ClassName = model.ClassName,
                            SubjectName = model.SubjectName,
                            StudentName = model.StudentName,
                            TotalMarks = model.TotalMarks,
                            ObtainedMarks = model.ObtainedMarks
                        };

                        // Save to database
                        db.Mark.Add(studentMark);
                        db.SaveChanges(); // Save changes to the database

                        // Set success message in TempData
                        TempData["success"] = "Marks added successfully.";

                        // Redirect to the action method with classId and subjectId
                        return RedirectToAction("MarkStudentMarks", "TeacherDashboard", new { classId = model.ClassId, subjectId = model.SubjectId });
                    }
                    else
                    {
                        // Obtained marks exceed total marks, display error message
                        TempData["error"] = "Obtained marks cannot exceed total marks,error";
                    }
                //}
                /*else
                {
                    // Negative marks are not allowed, display error message
                    TempData["error"] = "Obtained marks and total marks cannot be negative.";
                }*/
            }
            else
            {
                // If remarks are null, display an error message
                TempData["error"] = "Error";
            }

            // Return the view with the viewModel
            return View(viewModel);
        }

        public IActionResult ViewMarks()
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Once you have the teacher, use their TeacherId to find the assigned subjects
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Include(a => a.Subject.Class) // Assuming there is a navigation property from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId)
                .ToList();

            // Step 4: Retrieve the unique class names from the assigned subjects
            var uniqueClassNames = assignedSubjects.Select(a => a.Subject.Class.ClassName).Distinct().ToList();

            // Step 5: Create a ViewModel to represent the details
            var viewModel = new List<AssignedSubjects>(); // You may want to create a dedicated ViewModel for better organization

            foreach (var uniqueClassName in uniqueClassNames)
            {
                // For each unique class name, find the associated assigned subject (you might want to adjust this logic based on your requirements)
                var assignedSubject = assignedSubjects.FirstOrDefault(a => a.Subject.Class.ClassName == uniqueClassName);

                if (assignedSubject != null)
                {
                    var assignedSubjectViewModel = new AssignedSubjects
                    {
                        AssignedSubjectId = assignedSubject.AssignedSubjectId,
                        SubjectId = assignedSubject.SubjectId,
                        TeacherId = assignedSubject.TeacherId,
                        ClassId = assignedSubject.Subject.Class.ClassId,
                        Subject = assignedSubject.Subject,
                        SubjectList = assignedSubject.SubjectList,
                        TeachersList = assignedSubject.TeachersList,
                        ClassesList = assignedSubject.ClassesList,
                        SubjectName = assignedSubject.Subject.SubjectName,
                        Teachername = assignedSubject.Teachername,
                        ClassName = assignedSubject.Subject.Class.ClassName
                    };

                    viewModel.Add(assignedSubjectViewModel);
                }
            }

            return View(viewModel);
        }

        public IActionResult ViewClassMarks(int classId)
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve the assigned subjects for the specified class and teacher
            var assignedSubjects = db.assignedSubjects
                .Include(a => a.Subject)
                .Include(a => a.Subject.Class) // Assuming there is a navigation property from AssignedSubjects to Subjects and Subjects to Classes
                .Where(a => a.TeacherId == teacher.TeacherId && a.ClassId == classId)
                .ToList();

            // Step 4: Create a ViewModel to represent the details
            var viewModel = new List<AssignedSubjects>(); // Create a dedicated ViewModel for better organization

            foreach (var assignedSubject in assignedSubjects)
            {
                var assignedSubjectViewModel = new AssignedSubjects
                {
                    AssignedSubjectId = assignedSubject.AssignedSubjectId,
                    SubjectId = assignedSubject.SubjectId,
                    TeacherId = assignedSubject.TeacherId,
                    ClassId = assignedSubject.Subject.Class.ClassId,
                    SubjectName = assignedSubject.Subject.SubjectName,
                    Teachername = assignedSubject.Teachername,
                    ClassName = assignedSubject.Subject.Class.ClassName
                };

                viewModel.Add(assignedSubjectViewModel);
            }

            // You can pass the viewModel to the view or process it accordingly
            return View(viewModel);
        }

        public IActionResult ViewStudentMarks(int classId, int subjectId)
        {
            var studentsOfClass = db.students.Include(sa => sa.Class)
                .Where(sa => sa.ClassId == classId).ToList();

            // Step 3: Create a ViewModel to represent the student details
            var viewModel = new List<Marks>();

            var today = DateOnly.FromDateTime(DateTime.Today); // Get today's date as a DateOnly object

            foreach (var student in studentsOfClass)
            {
                var studentAttendance = db.StudentAttendances.FirstOrDefault(sa =>
                    sa.StudentId == student.StudentId &&
                    sa.SubjectId == subjectId &&
                    sa.ClassId == classId &&
                    sa.Date == today); // Check if a record for the student on the given date exists

                bool isAttendanceMarked = studentAttendance != null;

                var studentViewModel = new Marks
                {
                    Id = studentAttendance != null ? studentAttendance.Id : 0,
                    StudentId = student.StudentId,
                    ClassId = student.ClassId,
                    RollNo = student.StudentRollNo,
                    SubjectId = subjectId,
                    ClassName = student.Class.ClassName,
                    SubjectName = db.subjets.FirstOrDefault(s => s.SubjectId == subjectId)?.SubjectName, // Fetch subject name from database
                    StudentName = student.StudentName,
                    IsMarked = isAttendanceMarked // Flag indicating if attendance is already marked for the student on the given date
                };
                viewModel.Add(studentViewModel);
            }

            return View(viewModel);
        }

        public IActionResult ViewIndividualStudentMarks(int classId, int subjectId, int studentId)
        {
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
                    Id= record.Id,
                };

                // Add the studentViewModel to the list
                viewModel.Add(markViewModel);
            }

            // Step 5: Return the view with the populated ViewModel
            return View(viewModel);
        }

        public IActionResult EditStudentMarks(int id)
        {
            // Step 1: Retrieve the StudentAttendance record from the database based on the provided id
            var studentMarks = db.Mark.FirstOrDefault(sa => sa.Id == id);

            if (studentMarks == null)
            {
                // Handle the case when the StudentAttendance record is not found
                return RedirectToAction("Error", "Home");
            }

            // Step 2: Populate a ViewModel with the retrieved StudentAttendance record
            var viewModel = new Marks
            {
                StudentId = studentMarks.StudentId,
                SubjectId = studentMarks.SubjectId,
                ClassId = studentMarks.ClassId,
                Date = studentMarks.Date,
                TotalMarks = studentMarks.TotalMarks,
                ClassName = studentMarks.ClassName,
                SubjectName = studentMarks.SubjectName,
                StudentName = studentMarks.StudentName,
                RollNo = studentMarks.RollNo,
                ObtainedMarks= studentMarks.ObtainedMarks,
                TestName= studentMarks.TestName,
                // Add other properties as needed
            };

            // Step 3: Return the view with the populated ViewModel
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditStudentMarks(Marks model, int classId, int subjectId, int studentId)
        {
            // Step 1: Retrieve today's date
            var today = DateOnly.FromDateTime(DateTime.Today);

            // Step 2: Retrieve students of the specified class
            var studentsOfClass = db.students
                .Where(sa => sa.ClassId == model.ClassId)
                .Select(sa => new
                {
                    sa.StudentId,
                    sa.StudentRollNo,
                    sa.StudentName,
                    ClassName = sa.Class.ClassName
                })
                .ToList();

            // Step 3: Create a ViewModel to represent the student details
            var viewModel = studentsOfClass.Select(student => new Marks
            {
                StudentId = student.StudentId,
                ClassId = model.ClassId,
                RollNo = student.StudentRollNo,
                SubjectId = model.SubjectId,
                ClassName = student.ClassName,
                SubjectName = db.subjets.FirstOrDefault(s => s.SubjectId == model.SubjectId)?.SubjectName,
                StudentName = student.StudentName,
                IsMarked = db.Mark
                   .Any(sa => sa.StudentId == student.StudentId &&
                   sa.SubjectId == model.SubjectId &&
                   sa.ClassId == model.ClassId &&
                   sa.Id == model.Id)
            }).ToList();

            if (!string.IsNullOrEmpty(model.TestName) && model.TotalMarks != 0 && model.ObtainedMarks != 0)
            {
                var studentMarks = db.Mark.FirstOrDefault(sa => sa.Id == model.Id);

                if (studentMarks == null)
                {
                    // If the record is not found, set an error message and redirect to the dashboard
                    TempData["ErrorMessage"] = "Student attendance record not found.";
                    return RedirectToAction("MarkStudentAttendance", "TeacherDashboard");
                }

                try
                {
                    // Update the student attendance record with the new values from the model
                    studentMarks.Date = DateOnly.FromDateTime(DateTime.Today);
                    studentMarks.TestName = model.TestName;
                    studentMarks.TotalMarks = model.TotalMarks;
                    studentMarks.ObtainedMarks= model.ObtainedMarks;

                    // Save the changes to the database
                    db.SaveChanges();

                    // Set a success message and redirect to the dashboard
                    TempData["success"] = "Marks updated successfully.";

                    return RedirectToAction("ViewIndividualStudentMarks", "TeacherDashboard", new { classId, subjectId, studentId });
                }
                catch (Exception ex)
                {
                    // Handle any potential errors and display an error message
                    //TempData["ErrorMessage"] = "An error occurred while updating student attendance.";
                    // Log the exception if needed
                    return RedirectToAction("ViewStudentMarks", "TeacherDashboard");
                }
            }

            // If the model state is not valid, return the view with the model to display validation errors
            return View(viewModel);
        }

        public IActionResult ViewAttendanceRecord()
        {
            // Step 1: Retrieve the teacher's email from the session
            var teacherEmail = HttpContext.Session.GetString("TeacherEmail");

            if (string.IsNullOrEmpty(teacherEmail))
            {
                // Handle the case when the teacher email is not in the session
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 2: Use the email to find the teacher in the database
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherEmail == teacherEmail);

            if (teacher == null)
            {
                // Handle the case when the teacher is not found
                return RedirectToAction("Login", "Authentication"); // Redirect to login page or handle accordingly
            }

            // Step 3: Retrieve all attendance records for the specified teacher
            var attendanceRecords = db.StaffAttendances
                .Where(ta => ta.TeacherId == teacher.TeacherId)
                .ToList();

            // Step 4: Create a ViewModel to represent the teacher's attendance records
            var viewModel = new List<StaffAttendance>();

            // Populate the ViewModel with attendance records
            foreach (var record in attendanceRecords)
            {
                var teacherViewModel = new StaffAttendance
                {
                    Id = record.Id,
                    TeacherId = teacher.TeacherId,
                    Date = record.Date, // Populate Date
                    Remarks = record.Remarks // Populate Remarks
                };

                // Add the teacherViewModel to the list
                viewModel.Add(teacherViewModel);
            }

            // Step 5: Return the view with the populated ViewModel
            return View(viewModel);
        }


    }


}
