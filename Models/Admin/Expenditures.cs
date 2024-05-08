using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models.Admin
{
    public class Expenditures
    {
        [Key]
        public int ExpenditureId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ExpenditureTitle { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int ExpenditureAmount { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }

    }
}
