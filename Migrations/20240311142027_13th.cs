using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class _13th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedSubjectsTeacherDetails");

            migrationBuilder.AddColumn<int>(
                name: "AssignedSubjectsAssignedSubjectId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AssignedSubjectsAssignedSubjectId",
                table: "Teachers",
                column: "AssignedSubjectsAssignedSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_assignedSubjects_TeacherId",
                table: "assignedSubjects",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignedSubjects_Teachers_TeacherId",
                table: "assignedSubjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_assignedSubjects_AssignedSubjectsAssignedSubjectId",
                table: "Teachers",
                column: "AssignedSubjectsAssignedSubjectId",
                principalTable: "assignedSubjects",
                principalColumn: "AssignedSubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignedSubjects_Teachers_TeacherId",
                table: "assignedSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_assignedSubjects_AssignedSubjectsAssignedSubjectId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_AssignedSubjectsAssignedSubjectId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_assignedSubjects_TeacherId",
                table: "assignedSubjects");

            migrationBuilder.DropColumn(
                name: "AssignedSubjectsAssignedSubjectId",
                table: "Teachers");

            migrationBuilder.CreateTable(
                name: "AssignedSubjectsTeacherDetails",
                columns: table => new
                {
                    AssignedSubjectsAssignedSubjectId = table.Column<int>(type: "int", nullable: false),
                    TeachersListTeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedSubjectsTeacherDetails", x => new { x.AssignedSubjectsAssignedSubjectId, x.TeachersListTeacherId });
                    table.ForeignKey(
                        name: "FK_AssignedSubjectsTeacherDetails_Teachers_TeachersListTeacherId",
                        column: x => x.TeachersListTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedSubjectsTeacherDetails_assignedSubjects_AssignedSubjectsAssignedSubjectId",
                        column: x => x.AssignedSubjectsAssignedSubjectId,
                        principalTable: "assignedSubjects",
                        principalColumn: "AssignedSubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedSubjectsTeacherDetails_TeachersListTeacherId",
                table: "AssignedSubjectsTeacherDetails",
                column: "TeachersListTeacherId");
        }
    }
}
