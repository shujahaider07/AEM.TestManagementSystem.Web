using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEM.TestManagementSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CandidateIdaddedinregisterDtoandstudenttbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Candidate_ID",
                table: "Students",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Candidate_ID",
                table: "Students");
        }
    }
}
