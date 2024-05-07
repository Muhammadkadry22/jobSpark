using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobSpark.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GenerateTheRelationBetweenCompanyAndVacancyTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Vacancies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CompanyId",
                table: "Vacancies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Companies_CompanyId",
                table: "Vacancies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Companies_CompanyId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_CompanyId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Vacancies");
        }
    }
}
