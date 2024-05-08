using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class _23th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rollNo",
                table: "StudentAttendances",
                newName: "RollNo");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "StudentAttendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "StudentAttendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "StudentAttendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "StudentAttendances");

            migrationBuilder.RenameColumn(
                name: "RollNo",
                table: "StudentAttendances",
                newName: "rollNo");
        }
    }
}
