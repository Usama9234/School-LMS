using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class _19th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teachers_TeacherDetailsTeacherId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherDetailsTeacherId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherDetailsTeacherId",
                table: "Teachers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherDetailsTeacherId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    AssignedSubjectsAssignedSubjectId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    className = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rollNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAttendances_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAttendances_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAttendances_assignedSubjects_AssignedSubjectsAssignedSubjectId",
                        column: x => x.AssignedSubjectsAssignedSubjectId,
                        principalTable: "assignedSubjects",
                        principalColumn: "AssignedSubjectId");
                    table.ForeignKey(
                        name: "FK_StudentAttendances_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAttendances_subjets_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjets",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherDetailsTeacherId",
                table: "Teachers",
                column: "TeacherDetailsTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_AssignedSubjectsAssignedSubjectId",
                table: "StudentAttendances",
                column: "AssignedSubjectsAssignedSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_ClassId",
                table: "StudentAttendances",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_StudentId",
                table: "StudentAttendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_SubjectId",
                table: "StudentAttendances",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_TeacherId",
                table: "StudentAttendances",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Teachers_TeacherDetailsTeacherId",
                table: "Teachers",
                column: "TeacherDetailsTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId");
        }
    }
}
