using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerMigrations.Migrations
{
    public partial class Cascadedelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTemplate_Chief_ChiefId",
                table: "EventTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyEventTime_WeeklyEvent_WeeklyEventId",
                table: "WeeklyEventTime");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTemplate_Chief_ChiefId",
                table: "EventTemplate",
                column: "ChiefId",
                principalTable: "Chief",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyEventTime_WeeklyEvent_WeeklyEventId",
                table: "WeeklyEventTime",
                column: "WeeklyEventId",
                principalTable: "WeeklyEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTemplate_Chief_ChiefId",
                table: "EventTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyEventTime_WeeklyEvent_WeeklyEventId",
                table: "WeeklyEventTime");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTemplate_Chief_ChiefId",
                table: "EventTemplate",
                column: "ChiefId",
                principalTable: "Chief",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyEventTime_WeeklyEvent_WeeklyEventId",
                table: "WeeklyEventTime",
                column: "WeeklyEventId",
                principalTable: "WeeklyEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
