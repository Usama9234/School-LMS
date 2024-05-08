using Microsoft.EntityFrameworkCore;
using School_Management_System.Models.Admin;
using School_Management_System.Models;
using School_Management_System.Models.Teacher;

namespace School_Management_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Classes> Class { get; set; }

        public DbSet<Fees> fees { get; set; }

        public DbSet<Subjects> subjets { get; set; }

        public DbSet<StudentDetails> students { get; set; }

        public DbSet<TeacherDetails> Teachers { get; set; }

        public DbSet<AssignedSubjects> assignedSubjects { get; set; }


        public DbSet<StaffSalary> staffSalaries { get; set; }


        public DbSet<StaffAttendance> StaffAttendances { get; set; }


        public DbSet<Login> Login { get; set; }


        public DbSet<AdminCredentials> AdminCredential { get; set; }

        public DbSet<StudentAttendance> StudentAttendances { get; set; }

        public DbSet<LearningMaterial> LearningMaterials { get; set; }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<Marks> Mark { get; set; }

        public DbSet<Expenditures> Expenditure { get; set; }

        public DbSet<ClassWithStudentCount> ClassWithStudentCounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentAttendance>()
        .HasOne(sa => sa.Student)
        .WithMany()
        .HasForeignKey(sa => sa.StudentId)
        .OnDelete(DeleteBehavior.Restrict); // Specify the desired behavior here

            modelBuilder.Entity<StudentAttendance>()
                .HasOne(sa => sa.Subject)
                .WithMany()
                .HasForeignKey(sa => sa.SubjectId)
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired behavior here

            modelBuilder.Entity<StudentAttendance>()
                .HasOne(sa => sa.Class)
                .WithMany()
                .HasForeignKey(sa => sa.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LearningMaterial>()
        .HasOne(sa => sa.Class)
        .WithMany()
        .HasForeignKey(sa => sa.ClassId)
        .OnDelete(DeleteBehavior.Restrict); // Specify the desired behavior here

            modelBuilder.Entity<LearningMaterial>()
                .HasOne(sa => sa.Subject)
                .WithMany()
                .HasForeignKey(sa => sa.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Marks>()
        .HasOne(sa => sa.Student)
        .WithMany()
        .HasForeignKey(sa => sa.StudentId)
        .OnDelete(DeleteBehavior.Restrict); // Specify the desired behavior here

            modelBuilder.Entity<Marks>()
                .HasOne(sa => sa.Subject)
                .WithMany()
                .HasForeignKey(sa => sa.SubjectId)
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired behavior here

            modelBuilder.Entity<Marks>()
                .HasOne(sa => sa.Class)
                .WithMany()
                .HasForeignKey(sa => sa.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Parent>()
                .HasOne(sa => sa.Class)
                .WithMany()
                .HasForeignKey(sa => sa.ClassId)
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired behavior here

            modelBuilder.Entity<Parent>()
                .HasOne(sa => sa.Students)
                .WithMany()
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
