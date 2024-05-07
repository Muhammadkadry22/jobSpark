using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobSpark.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateApplicantTableAndItRelationWithProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brief = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ApplicantId",
                table: "Projects",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Applicants_ApplicantId",
                table: "Projects",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Applicants_ApplicantId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ApplicantId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "Projects");
        }
    }
}
