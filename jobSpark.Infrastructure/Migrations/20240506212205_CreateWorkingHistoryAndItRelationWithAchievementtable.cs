using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobSpark.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateWorkingHistoryAndItRelationWithAchievementtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkingHistoryId",
                table: "Achievements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkingHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHistories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_WorkingHistoryId",
                table: "Achievements",
                column: "WorkingHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_WorkingHistories_WorkingHistoryId",
                table: "Achievements",
                column: "WorkingHistoryId",
                principalTable: "WorkingHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_WorkingHistories_WorkingHistoryId",
                table: "Achievements");

            migrationBuilder.DropTable(
                name: "WorkingHistories");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_WorkingHistoryId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "WorkingHistoryId",
                table: "Achievements");
        }
    }
}
