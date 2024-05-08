using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models.Admin
{
    public class StaffAttendance
    {
        [Key]
        public int Id { get; set; }


        public int TeacherId { get; set; }

        public virtual TeacherDetails Teacher { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        public DateOnly Date { get; set; }

        public List<TeacherDetails> TeachersList { get; set; }

        public string? teacherName { get; set; }

        public string Remarks { get; set; }
    }
}
