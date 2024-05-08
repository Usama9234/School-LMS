using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class _15th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_students_StudentId",
                table: "StudentAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_students_StudentAttendances_StudentAttendanceId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_StudentAttendanceId",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAttendances",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "StudentAttendanceId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "studentName",
                table: "StudentAttendances");

            migrationBuilder.RenameTable(
                name: "StudentAttendances",
                newName: "StudentAttendance");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_StudentId",
                table: "StudentAttendance",
                newName: "IX_StudentAttendance_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "AssignedSubjectsAssignedSubjectId",
                table: "StudentAttendance",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "StudentAttendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "StudentAttendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "StudentAttendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAttendance",
                table: "StudentAttendance",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendance_AssignedSubjectsAssignedSubjectId",
                table: "StudentAttendance",
                column: "AssignedSubjectsAssignedSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendance_ClassId",
                table: "StudentAttendance",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendance_SubjectId",
                table: "StudentAttendance",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendance_TeacherId",
                table: "StudentAttendance",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendance_Class_ClassId",
                table: "StudentAttendance",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendance_Teachers_TeacherId",
                table: "StudentAttendance",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendance_assignedSubjects_AssignedSubjectsAssignedSubjectId",
                table: "StudentAttendance",
                column: "AssignedSubjectsAssignedSubjectId",
                principalTable: "assignedSubjects",
                principalColumn: "AssignedSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendance_students_StudentId",
                table: "StudentAttendance",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendance_subjets_SubjectId",
                table: "StudentAttendance",
                column: "SubjectId",
                principalTable: "subjets",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendance_Class_ClassId",
                table: "StudentAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendance_Teachers_TeacherId",
                table: "StudentAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendance_assignedSubjects_AssignedSubjectsAssignedSubjectId",
                table: "StudentAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendance_students_StudentId",
                table: "StudentAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendance_subjets_SubjectId",
                table: "StudentAttendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAttendance",
                table: "StudentAttendance");

            migrationBuilder.DropIndex(
                name: "IX_StudentAttendance_AssignedSubjectsAssignedSubjectId",
                table: "StudentAttendance");

            migrationBuilder.DropIndex(
                name: "IX_StudentAttendance_ClassId",
                table: "StudentAttendance");

            migrationBuilder.DropIndex(
                name: "IX_StudentAttendance_SubjectId",
                table: "StudentAttendance");

            migrationBuilder.DropIndex(
                name: "IX_StudentAttendance_TeacherId",
                table: "StudentAttendance");

            migrationBuilder.DropColumn(
                name: "AssignedSubjectsAssignedSubjectId",
                table: "StudentAttendance");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "StudentAttendance");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "StudentAttendance");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "StudentAttendance");

            migrationBuilder.RenameTable(
                name: "StudentAttendance",
                newName: "StudentAttendances");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendance_StudentId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "StudentAttendanceId",
                table: "students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "studentName",
                table: "StudentAttendances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAttendances",
                table: "StudentAttendances",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_students_StudentAttendanceId",
                table: "students",
                column: "StudentAttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_students_StudentId",
                table: "StudentAttendances",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_StudentAttendances_StudentAttendanceId",
                table: "students",
                column: "StudentAttendanceId",
                principalTable: "StudentAttendances",
                principalColumn: "Id");
        }
    }
}
