using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models.Admin
{
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ParentName { get; set; }


        [Required]
        [StringLength(11)] // Adjust the length based on your requirements
        [RegularExpression(@"^\d+$", ErrorMessage = "Mobile number must contain only numeric characters.")]
        public string MobileNumber { get; set; }


        [Required]
        [EmailAddress]
        public string ParentEmail { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string ParentAdress { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [BindProperty]
        public int ClassId { get; set; }


        [BindProperty]
        public virtual Classes Class { get; set; }


        [BindProperty]
        public List<Classes> ClassesList { get; set; }

        [BindProperty]
        public int StudentId { get; set; }


        [BindProperty]
        public virtual StudentDetails Students { get; set; }


        [BindProperty]
        public List<StudentDetails> StudentsList { get; set; }

        public string StudentName {  get; set; }

        public string ClassName { get; set; }

    }

}
