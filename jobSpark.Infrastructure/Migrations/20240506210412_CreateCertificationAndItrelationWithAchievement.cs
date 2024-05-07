using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobSpark.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateCertificationAndItrelationWithAchievement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CertificationId",
                table: "Achievements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_CertificationId",
                table: "Achievements",
                column: "CertificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Certifications_CertificationId",
                table: "Achievements",
                column: "CertificationId",
                principalTable: "Certifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Certifications_CertificationId",
                table: "Achievements");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_CertificationId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "CertificationId",
                table: "Achievements");
        }
    }
}
