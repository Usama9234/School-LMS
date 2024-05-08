using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class _50th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotlaIncome",
                table: "ClassWithStudentCounts",
                newName: "TotalIncome");

            migrationBuilder.AlterColumn<long>(
                name: "ClassIncome",
                table: "ClassWithStudentCounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalIncome",
                table: "ClassWithStudentCounts",
                newName: "TotlaIncome");

            migrationBuilder.AlterColumn<int>(
                name: "ClassIncome",
                table: "ClassWithStudentCounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
