using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class _42th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentAdress",
                table: "Parents",
                newName: "ParentAdress");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Parents");

            migrationBuilder.RenameColumn(
                name: "ParentAdress",
                table: "Parents",
                newName: "StudentAdress");
        }
    }
}
