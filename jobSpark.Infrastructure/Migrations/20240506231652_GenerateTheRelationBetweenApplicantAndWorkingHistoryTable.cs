using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobSpark.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GenerateTheRelationBetweenApplicantAndWorkingHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "WorkingHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHistories_ApplicantId",
                table: "WorkingHistories",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHistories_Applicants_ApplicantId",
                table: "WorkingHistories",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHistories_Applicants_ApplicantId",
                table: "WorkingHistories");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHistories_ApplicantId",
                table: "WorkingHistories");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "WorkingHistories");
        }
    }
}
