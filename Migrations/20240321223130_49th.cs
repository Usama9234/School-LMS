﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class _49th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassIncome",
                table: "Expenditure");

            migrationBuilder.DropColumn(
                name: "TotlaIncome",
                table: "Expenditure");

            migrationBuilder.AddColumn<int>(
                name: "ClassIncome",
                table: "ClassWithStudentCounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotlaIncome",
                table: "ClassWithStudentCounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassIncome",
                table: "ClassWithStudentCounts");

            migrationBuilder.DropColumn(
                name: "TotlaIncome",
                table: "ClassWithStudentCounts");

            migrationBuilder.AddColumn<int>(
                name: "ClassIncome",
                table: "Expenditure",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotlaIncome",
                table: "Expenditure",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}