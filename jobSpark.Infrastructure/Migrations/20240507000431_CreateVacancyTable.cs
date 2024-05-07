using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobSpark.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateVacancyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantCount = table.Column<int>(type: "int", nullable: true),
                    ReviewCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacancies");
        }
    }
}
