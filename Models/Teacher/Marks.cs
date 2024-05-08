using School_Management_System.Models.Admin;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models.Teacher
{
    public class Marks
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual StudentDetails Student { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subjects Subject { get; set; }

        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual Classes Class { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        public DateOnly Date { get; set; }

        public int ObtainedMarks { get; set; }

        public string RollNo { get; set; }

        public string ClassName { get; set; }

        public string SubjectName { get; set; }

        public string StudentName { get; set; }

        public bool IsMarked { get; set; }

        public string TestName { get; set; }

        public int TotalMarks { get; set; }
    }
}
