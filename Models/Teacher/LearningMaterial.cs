using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using School_Management_System.Models.Admin;

namespace School_Management_System.Models.Teacher
{
    public class LearningMaterial
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the title.")]
        [StringLength(100, ErrorMessage = "The title must be at most 100 characters long.")]
        public string Title { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name = "Upload Date")]
        public DateTime UploadDate { get; set; }

        public Classes Class { get; set; }
        public Subjects Subject { get; set; }

        public int ClassId { get; set; }

        public int SubjectId { get; set; }

        public List<Classes> ClassesList { get; set; }

        public List<AssignedSubjects> AssignedSubjectList { get; set; }

        public string ?ClassName {  get; set; }

        public string ?SubjectName { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public long SizeBytes { get; set; }


    }
}
