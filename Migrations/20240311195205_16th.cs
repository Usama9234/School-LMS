using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class _16th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "StudentAttendance",
                newName: "StudentAttendances");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendance_TeacherId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendance_SubjectId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendance_StudentId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendance_ClassId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendance_AssignedSubjectsAssignedSubjectId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_AssignedSubjectsAssignedSubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAttendances",
                table: "StudentAttendances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_Class_ClassId",
                table: "StudentAttendances",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_Teachers_TeacherId",
                table: "StudentAttendances",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_assignedSubjects_AssignedSubjectsAssignedSubjectId",
                table: "StudentAttendances",
                column: "AssignedSubjectsAssignedSubjectId",
                principalTable: "assignedSubjects",
                principalColumn: "AssignedSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_students_StudentId",
                table: "StudentAttendances",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_subjets_SubjectId",
                table: "StudentAttendances",
                column: "SubjectId",
                principalTable: "subjets",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_Class_ClassId",
                table: "StudentAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_Teachers_TeacherId",
                table: "StudentAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_assignedSubjects_AssignedSubjectsAssignedSubjectId",
                table: "StudentAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_students_StudentId",
                table: "StudentAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_subjets_SubjectId",
                table: "StudentAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAttendances",
                table: "StudentAttendances");

            migrationBuilder.RenameTable(
                name: "StudentAttendances",
                newName: "StudentAttendance");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_TeacherId",
                table: "StudentAttendance",
                newName: "IX_StudentAttendance_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_SubjectId",
                table: "StudentAttendance",
                newName: "IX_StudentAttendance_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_StudentId",
                table: "StudentAttendance",
                newName: "IX_StudentAttendance_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_ClassId",
                table: "StudentAttendance",
                newName: "IX_StudentAttendance_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_AssignedSubjectsAssignedSubjectId",
                table: "StudentAttendance",
                newName: "IX_StudentAttendance_AssignedSubjectsAssignedSubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAttendance",
                table: "StudentAttendance",
                column: "Id");

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
    }
}
