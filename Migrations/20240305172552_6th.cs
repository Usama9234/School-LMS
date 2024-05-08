using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class _6th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffAttendanceId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StaffAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffAttendances_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_StaffAttendanceId",
                table: "Teachers",
                column: "StaffAttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAttendances_TeacherId",
                table: "StaffAttendances",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_StaffAttendances_StaffAttendanceId",
                table: "Teachers",
                column: "StaffAttendanceId",
                principalTable: "StaffAttendances",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_StaffAttendances_StaffAttendanceId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "StaffAttendances");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_StaffAttendanceId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StaffAttendanceId",
                table: "Teachers");
        }
    }
}
