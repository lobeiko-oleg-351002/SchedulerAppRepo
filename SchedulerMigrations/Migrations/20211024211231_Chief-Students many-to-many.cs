using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SchedulerMigrations.Migrations
{
    public partial class ChiefStudentsmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Chief_ChiefId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ChiefId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ChiefId",
                table: "Student");

            migrationBuilder.CreateTable(
                name: "ChiefStudent",
                columns: table => new
                {
                    ChiefsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiefStudent", x => new { x.ChiefsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ChiefStudent_Chief_ChiefsId",
                        column: x => x.ChiefsId,
                        principalTable: "Chief",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiefStudent_Student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiefStudent_StudentsId",
                table: "ChiefStudent",
                column: "StudentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiefStudent");

            migrationBuilder.AddColumn<Guid>(
                name: "ChiefId",
                table: "Student",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_ChiefId",
                table: "Student",
                column: "ChiefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Chief_ChiefId",
                table: "Student",
                column: "ChiefId",
                principalTable: "Chief",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
