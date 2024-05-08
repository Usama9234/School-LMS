using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class _34th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaterialData",
                table: "LearningMaterials",
                newName: "DataFiles");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                table: "LearningMaterials",
                newName: "FileType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "LearningMaterials",
                newName: "ContentType");

            migrationBuilder.RenameColumn(
                name: "DataFiles",
                table: "LearningMaterials",
                newName: "MaterialData");
        }
    }
}
