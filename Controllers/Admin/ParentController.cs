using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mono.TextTemplating;
using School_Management_System.Data;
using School_Management_System.Models.Admin;

namespace School_Management_System.Controllers.Admin
{
    public class ParentController : Controller
    {
        private readonly ApplicationDbContext db;

        public ParentController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddParent()
        {
            var classList = db.Class.ToList();
            var studentsList = db.students.ToList();

            // Assuming you want to initialize the properties of AssignedSubjects
            var model = new Parent
            {
                StudentsList = studentsList, 
                ClassesList = classList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddParent(Parent obj)
        {
            var classList = db.Class.ToList();
            var studentsList = db.students.ToList();
            var model = new Parent
            {
                StudentsList = studentsList,
                ClassesList = classList
            };

            ModelState.Remove("ClassId");
            ModelState.Remove("Class");
            ModelState.Remove("ClassesList");
            ModelState.Remove("StudentId");
            ModelState.Remove("Students");
            ModelState.Remove("StudentsList");
            ModelState.Remove("StudentName");
            ModelState.Remove("ClassName");

            if (ModelState.IsValid)
            {
                if (obj.ClassId <= 0 || obj.StudentId <= 0)
                {
                    TempData["error"] = "Please select both Student and Class";
                    ModelState.Remove("ClassId");
                    return View(model);
                }
                if (db.students.Any(c => c.Password == obj.Password) || db.Teachers.Any(c => c.Password == obj.Password) || db.Parents.Any(c => c.Password == obj.Password))
                {
                    ModelState.AddModelError("Password", "Password already exists.");
                    return View(model);
                }
                var existingParent = db.Parents.FirstOrDefault(p => p.StudentId == obj.StudentId && p.ClassId == obj.ClassId);

                if (existingParent != null)
                {
                    // Update existing parent record with new details
                    existingParent.ParentName = obj.ParentName;
                    existingParent.MobileNumber = obj.MobileNumber;
                    existingParent.ParentEmail = obj.ParentEmail;
                    existingParent.ParentAdress = obj.ParentAdress;
                    existingParent.Password = obj.Password;

                    db.SaveChanges();
                    TempData["success"] = "Parent details updated successfully";
                    return RedirectToAction("ViewAllClassesParents");
                }
                else
                {
                    var selectedStudentName = studentsList.FirstOrDefault(s => s.StudentId == obj.StudentId)?.StudentName;
                    var selectedClassName = classList.FirstOrDefault(c => c.ClassId == obj.ClassId)?.ClassName;

                    // Create a new parent record
                    var newParentDetails = new Parent
                    {
                        ParentId = obj.ParentId,
                        StudentId = obj.StudentId,
                        ClassId = obj.ClassId,
                        StudentName = selectedStudentName,
                        ClassName = selectedClassName,
                        ParentName = obj.ParentName,
                        MobileNumber = obj.MobileNumber,
                        ParentEmail = obj.ParentEmail,
                        ParentAdress = obj.ParentAdress,
                        Password = obj.Password
                    };

                    db.Parents.Add(newParentDetails);
                    db.SaveChanges();
                    TempData["success"] = "Parent Added Successfully";
                    return RedirectToAction("ViewAllClassesParents");
                }
            }

            return View(model);
        }

        public IActionResult GetStudents(int classId)
        {
            var students = db.students
                .Where(s => s.ClassId == classId)
                .Select(s => new { s.StudentId, s.StudentName })
                .ToList();

            return Json(students);
        }

        public IActionResult ViewAllClassesParents()
        {
            List<Classes> objList = db.Class.ToList();
            return View(objList);
        }

        public IActionResult ViewClassParents(int classId)
        {
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

        public IActionResult ViewStudentParent(int studentId)
        {
            // Step 3: Retrieve the parent of the specified student
            var parentofSpecificStudent = db.Parents.Where(s => s.StudentId == studentId) // Assuming there is a property ClassId in the Student model
                .ToList();

            // Step 4: Create a ViewModel to represent the student details
            var viewModel = new List<Parent>(); // You may want to create a dedicated ViewModel for better organization

            foreach (var parent in parentofSpecificStudent)
            {
                var studentViewModel = new Parent
                {
                    ParentId = parent.ParentId,
                    StudentId = parent.StudentId,
                    StudentName = parent.StudentName,
                    ParentName= parent.ParentName,
                    MobileNumber = parent.MobileNumber,
                    ParentEmail = parent.ParentEmail,
                    ParentAdress = parent.ParentAdress,
                    Password = parent.Password,
                    ClassId = parent.ClassId,
                    ClassName= parent.ClassName,
                };

                viewModel.Add(studentViewModel);
            }

            return View(viewModel);
        }

        public IActionResult EditParent(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Parent? categoryFromDb = db.Parents.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult EditParent(Parent obj)
        {
            ModelState.Remove("ClassId");
            ModelState.Remove("Class");
            ModelState.Remove("ClassesList");
            ModelState.Remove("StudentId");
            ModelState.Remove("Students");
            ModelState.Remove("StudentsList");
            ModelState.Remove("StudentName");
            ModelState.Remove("ClassName");

            var classList = db.Class.ToList();
            var studentsList = db.students.ToList();
            var model = new Parent
            {
                StudentsList = studentsList,
                ClassesList = classList
            };

            if (ModelState.IsValid)
            {
                if (db.students.Any(c => c.Password == obj.Password) || db.Teachers.Any(c => c.Password == obj.Password) || db.Parents.Any(c => c.Password == obj.Password))
                {
                    ModelState.AddModelError("Password", "Password already exists.");
                    return View(model);
                }


                var existingParent = db.Parents.FirstOrDefault(p =>  p.ParentId == obj.ParentId);

                if (existingParent != null)
                {
                    // Update existing parent record with new details
                    existingParent.ParentName = obj.ParentName;
                    existingParent.MobileNumber = obj.MobileNumber;
                    existingParent.ParentEmail = obj.ParentEmail;
                    existingParent.ParentAdress = obj.ParentAdress;
                    existingParent.Password = obj.Password;

                    db.SaveChanges();
                    TempData["success"] = "Parent Updated Successfully";
                    return RedirectToAction("ViewAllClassesParents");
                }

            }

            return View(model);
        }

        public IActionResult DeleteParent(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Parent? categoryFromDb = db.Parents.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Delete the Parent
        [HttpPost, ActionName("DeleteParent")]
        public IActionResult DeleteParent(int? id)
        {
            var parentToDelete = db.Parents.Find(id);

            if (parentToDelete != null)
            {
                db.Parents.Remove(parentToDelete);
                db.SaveChanges();
                TempData["success"] = "Parent Deleted Successfully";
            }
            else
            {
                TempData["error"] = "Parent not found";
            }

            return RedirectToAction("ViewAllClassesParents");

        }
    }
}
