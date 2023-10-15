using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEM.TestManagementSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class exams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Exam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Exam",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Exam",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Exam",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Exam",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Exam",
                type: "datetime",
                nullable: true);
        }
    }
}
