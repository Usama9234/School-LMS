using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class _25th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LearningMaterialId",
                table: "Class",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LearningMaterialId",
                table: "assignedSubjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LearningMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningMaterials_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LearningMaterials_subjets_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjets",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_LearningMaterialId",
                table: "Class",
                column: "LearningMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_assignedSubjects_LearningMaterialId",
                table: "assignedSubjects",
                column: "LearningMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterials_ClassId",
                table: "LearningMaterials",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterials_SubjectId",
                table: "LearningMaterials",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignedSubjects_LearningMaterials_LearningMaterialId",
                table: "assignedSubjects",
                column: "LearningMaterialId",
                principalTable: "LearningMaterials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_LearningMaterials_LearningMaterialId",
                table: "Class",
                column: "LearningMaterialId",
                principalTable: "LearningMaterials",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignedSubjects_LearningMaterials_LearningMaterialId",
                table: "assignedSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_LearningMaterials_LearningMaterialId",
                table: "Class");

            migrationBuilder.DropTable(
                name: "LearningMaterials");

            migrationBuilder.DropIndex(
                name: "IX_Class_LearningMaterialId",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_assignedSubjects_LearningMaterialId",
                table: "assignedSubjects");

            migrationBuilder.DropColumn(
                name: "LearningMaterialId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "LearningMaterialId",
                table: "assignedSubjects");
        }
    }
}
