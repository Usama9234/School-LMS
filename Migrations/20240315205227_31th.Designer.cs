﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School_Management_System.Data;

#nullable disable

namespace School_Management_System.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240315205227_31th")]
    partial class _31th
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("School_Management_System.Models.Admin.AdminCredentials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdminCredential");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.AssignedSubjects", b =>
                {
                    b.Property<int>("AssignedSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignedSubjectId"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LearningMaterialId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Teachername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssignedSubjectId");

                    b.HasIndex("LearningMaterialId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("assignedSubjects");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.Classes", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<int?>("AssignedSubjectsAssignedSubjectId")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FeesFeeId")
                        .HasColumnType("int");

                    b.Property<int?>("LearningMaterialId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentDetailsStudentId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectsSubjectId")
                        .HasColumnType("int");

                    b.HasKey("ClassId");

                    b.HasIndex("AssignedSubjectsAssignedSubjectId");

                    b.HasIndex("FeesFeeId");

                    b.HasIndex("LearningMaterialId");

                    b.HasIndex("StudentDetailsStudentId");

                    b.HasIndex("SubjectsSubjectId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.Fees", b =>
                {
                    b.Property<int>("FeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeeId"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("FeeAmount")
                        .HasColumnType("int");

                    b.HasKey("FeeId");

                    b.HasIndex("ClassId");

                    b.ToTable("fees");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.StaffAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("teacherName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("StaffAttendances");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.StaffSalary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SalaryAmount")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("staffSalaries");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.StudentDetails", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentAdress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("StudentDOB")
                        .HasColumnType("date");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentRollNo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.ToTable("students");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.Subjects", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<int?>("AssignedSubjectsAssignedSubjectId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SubjectId");

                    b.HasIndex("AssignedSubjectsAssignedSubjectId");

                    b.HasIndex("ClassId");

                    b.ToTable("subjets");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.TeacherDetails", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<int?>("AssignedSubjectsAssignedSubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StaffAttendanceId")
                        .HasColumnType("int");

                    b.Property<int?>("StaffSalaryId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherAdress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("TeacherDOB")
                        .HasColumnType("date");

                    b.Property<string>("TeacherEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeacherId");

                    b.HasIndex("AssignedSubjectsAssignedSubjectId");

                    b.HasIndex("StaffAttendanceId");

                    b.HasIndex("StaffSalaryId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("School_Management_System.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("School_Management_System.Models.Teacher.LearningMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("MaterialData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.ToTable("LearningMaterials");
                });

            modelBuilder.Entity("School_Management_System.Models.Teacher.StudentAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<bool>("IsAttendanceMarked")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentAttendances");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.AssignedSubjects", b =>
                {
                    b.HasOne("School_Management_System.Models.Teacher.LearningMaterial", null)
                        .WithMany("AssignedSubjectList")
                        .HasForeignKey("LearningMaterialId");

                    b.HasOne("School_Management_System.Models.Admin.Subjects", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_Management_System.Models.Admin.TeacherDetails", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.Classes", b =>
                {
                    b.HasOne("School_Management_System.Models.Admin.AssignedSubjects", null)
                        .WithMany("ClassesList")
                        .HasForeignKey("AssignedSubjectsAssignedSubjectId");

                    b.HasOne("School_Management_System.Models.Admin.Fees", null)
                        .WithMany("ClassesList")
                        .HasForeignKey("FeesFeeId");

                    b.HasOne("School_Management_System.Models.Teacher.LearningMaterial", null)
                        .WithMany("ClassesList")
                        .HasForeignKey("LearningMaterialId");

                    b.HasOne("School_Management_System.Models.Admin.StudentDetails", null)
                        .WithMany("ClassesList")
                        .HasForeignKey("StudentDetailsStudentId");

                    b.HasOne("School_Management_System.Models.Admin.Subjects", null)
                        .WithMany("ClassesList")
                        .HasForeignKey("SubjectsSubjectId");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.Fees", b =>
                {
                    b.HasOne("School_Management_System.Models.Admin.Classes", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.StaffAttendance", b =>
                {
                    b.HasOne("School_Management_System.Models.Admin.TeacherDetails", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.StaffSalary", b =>
                {
                    b.HasOne("School_Management_System.Models.Admin.TeacherDetails", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.StudentDetails", b =>
                {
                    b.HasOne("School_Management_System.Models.Admin.Classes", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.Subjects", b =>
                {
                    b.HasOne("School_Management_System.Models.Admin.AssignedSubjects", null)
                        .WithMany("SubjectList")
                        .HasForeignKey("AssignedSubjectsAssignedSubjectId");

                    b.HasOne("School_Management_System.Models.Admin.Classes", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.TeacherDetails", b =>
                {
                    b.HasOne("School_Management_System.Models.Admin.AssignedSubjects", null)
                        .WithMany("TeachersList")
                        .HasForeignKey("AssignedSubjectsAssignedSubjectId");

                    b.HasOne("School_Management_System.Models.Admin.StaffAttendance", null)
                        .WithMany("TeachersList")
                        .HasForeignKey("StaffAttendanceId");

                    b.HasOne("School_Management_System.Models.Admin.StaffSalary", null)
                        .WithMany("TeacherLists")
                        .HasForeignKey("StaffSalaryId");
                });

            modelBuilder.Entity("School_Management_System.Models.Teacher.LearningMaterial", b =>
                {
                    b.HasOne("School_Management_System.Models.Admin.Classes", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("School_Management_System.Models.Admin.Subjects", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("School_Management_System.Models.Teacher.StudentAttendance", b =>
                {
                    b.HasOne("School_Management_System.Models.Admin.Classes", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("School_Management_System.Models.Admin.StudentDetails", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("School_Management_System.Models.Admin.Subjects", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.AssignedSubjects", b =>
                {
                    b.Navigation("ClassesList");

                    b.Navigation("SubjectList");

                    b.Navigation("TeachersList");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.Fees", b =>
                {
                    b.Navigation("ClassesList");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.StaffAttendance", b =>
                {
                    b.Navigation("TeachersList");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.StaffSalary", b =>
                {
                    b.Navigation("TeacherLists");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.StudentDetails", b =>
                {
                    b.Navigation("ClassesList");
                });

            modelBuilder.Entity("School_Management_System.Models.Admin.Subjects", b =>
                {
                    b.Navigation("ClassesList");
                });

            modelBuilder.Entity("School_Management_System.Models.Teacher.LearningMaterial", b =>
                {
                    b.Navigation("AssignedSubjectList");

                    b.Navigation("ClassesList");
                });
#pragma warning restore 612, 618
        }
    }
}
