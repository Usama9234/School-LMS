using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models.Admin;

namespace School_Management_System.Controllers.Admin
{
    public class ExpenditureController : Controller
    {
        private readonly ApplicationDbContext db;

        public ExpenditureController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult ViewExpenditures()
        {
            // Get all expenditures from the database
            List<Expenditures> objList = db.Expenditure.ToList();

            // Calculate the sum of all expenditure amounts
            decimal totalExpenditure = objList.Sum(e => e.ExpenditureAmount);

            // Pass the total expenditure along with the list of expenditures to the view
            ViewBag.SumOfAllExpenditures = totalExpenditure;
            return View(objList);
        }

        public IActionResult CreateExpenditure()
        {
            return View();
        }

        //Create or Add New Expenditure
        [HttpPost]
        public IActionResult CreateExpenditure(Expenditures obj)
        {
            if (ModelState.IsValid)
            {
                if (db.Expenditure.Any(c => c.ExpenditureTitle == obj.ExpenditureTitle&&c.Date==obj.Date && c.Time == obj.Time))
                {
                    ModelState.AddModelError("ExpenditureTitle", "Same Title Name on Same Date and time already exists.");
                    return View();
                }
                obj.Time = TimeOnly.FromDateTime(DateTime.Now);
                db.Expenditure.Add(obj);
                db.SaveChanges();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("ViewExpenditures");
            }
            return View();
        }


        //Edit the Expenditure
        public IActionResult EditExpenditure(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Expenditures? categoryFromDb = db.Expenditure.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [HttpPost]
        public IActionResult EditExpenditure(Expenditures obj)
        {
            if (ModelState.IsValid)
            {
                if (db.Expenditure.Any(c => c.ExpenditureTitle == obj.ExpenditureTitle && c.Date == obj.Date && c.Time == obj.Time))
                {
                    ModelState.AddModelError("ExpenditureTitle", "Same Title Name on Same Date and time already exists.");
                    return View();
                }

                // Retrieve the original Expenditure
                var originalExpenditure = db.Expenditure.Find(obj.ExpenditureId);

                if (originalExpenditure != null)
                {
                    // Update Expenditure information
                    originalExpenditure.ExpenditureTitle = obj.ExpenditureTitle;
                    originalExpenditure.ExpenditureAmount = obj.ExpenditureAmount;
                    originalExpenditure.Date = obj.Date;
                    originalExpenditure.Time = TimeOnly.FromDateTime(DateTime.Now); ;
                    db.SaveChanges();
                    TempData["success"] = "Expenditure Updated Successfully";
                }
                else
                {
                    TempData["error"] = "Expenditure not found";
                }

                return RedirectToAction("ViewExpenditures");
            }

            return View();
        }


        //Delete the Expenditure
        public IActionResult DeleteExpenditure(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Expenditures? categoryFromDb = db.Expenditure.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Delete the Expenditure
        [HttpPost, ActionName("DeleteExpenditure")]
        public IActionResult DeleteExpenditures(int? id)
        {
            Expenditures? obj = db.Expenditure.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            db.Expenditure.Remove(obj);
            db.SaveChanges();
            TempData["success"] = "Expenditure Deleted Successfully";
            return RedirectToAction("ViewExpenditures");

        }


        public IActionResult ViewIncome()
        {
            var classDetails = db.Class
        .GroupJoin(db.students,
            c => c.ClassId,
            s => s.ClassId,
            (c, students) => new
            {
                ClassName = c.ClassName,
                NumberOfStudents = students.Count(),
                FeeAmount = db.fees.FirstOrDefault(f => f.ClassId == c.ClassId) // Get the FeeAmount without using the null-conditional operator
            })
        .Select(x => new ClassWithStudentCount
        {
            ClassName = x.ClassName,
            StudentCount = x.NumberOfStudents,
            ClassIncome = x.FeeAmount != null ? x.NumberOfStudents * x.FeeAmount.FeeAmount : 0 // Calculate class income
        })
        .ToList();

            // Calculate the sum of all classes' income
            var totalIncome = classDetails.Sum(x => x.ClassIncome);

            // Set the TotalIncome property in each class detail
            foreach (var detail in classDetails)
            {
                detail.TotalIncome = totalIncome;
            }
            ViewBag.SumOfAllClassesIncome = totalIncome;
            return View(classDetails);
        }
    }
}
