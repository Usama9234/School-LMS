using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models.Admin
{
    public class Fees
    {
        [Key]
        public int FeeId { get; set; }

        [Required]
        public int ClassId { get; set; }

        public virtual Classes Class { get; set; }

        [Required]
        public List<Classes> ClassesList { get; set; }

        [Required(ErrorMessage = "Fee amount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid fee amount ")]
        public int FeeAmount { get; set; }
    }
}
