using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SchedulerMigrations.Migrations
{
    public partial class Fixmanytomanyrelationsseedinitdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOfWeek_WeeklyEventTime_WeeklyEventTimeId",
                table: "DayOfWeek");

            migrationBuilder.DropIndex(
                name: "IX_DayOfWeek_WeeklyEventTimeId",
                table: "DayOfWeek");

            migrationBuilder.DropColumn(
                name: "WeeklyEventTimeId",
                table: "DayOfWeek");

            migrationBuilder.CreateTable(
                name: "DayOfWeekWeeklyEventTime",
                columns: table => new
                {
                    DaysOfWeekId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeeklyEventTimesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfWeekWeeklyEventTime", x => new { x.DaysOfWeekId, x.WeeklyEventTimesId });
                    table.ForeignKey(
                        name: "FK_DayOfWeekWeeklyEventTime_DayOfWeek_DaysOfWeekId",
                        column: x => x.DaysOfWeekId,
                        principalTable: "DayOfWeek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayOfWeekWeeklyEventTime_WeeklyEventTime_WeeklyEventTimesId",
                        column: x => x.WeeklyEventTimesId,
                        principalTable: "WeeklyEventTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_DayOfWeekWeeklyEventTime_WeeklyEventTimesId",
                table: "DayOfWeekWeeklyEventTime",
                column: "WeeklyEventTimesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOfWeekWeeklyEventTime");

            migrationBuilder.AddColumn<Guid>(
                name: "WeeklyEventTimeId",
                table: "DayOfWeek",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayOfWeek_WeeklyEventTimeId",
                table: "DayOfWeek",
                column: "WeeklyEventTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfWeek_WeeklyEventTime_WeeklyEventTimeId",
                table: "DayOfWeek",
                column: "WeeklyEventTimeId",
                principalTable: "WeeklyEventTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
