using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models.Admin
{
    public class ClassWithStudentCount
    {
        [Key]
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int StudentCount { get; set; }

        public long ClassIncome { get; set; }

        public long TotalIncome { get; set; }
    }
}
