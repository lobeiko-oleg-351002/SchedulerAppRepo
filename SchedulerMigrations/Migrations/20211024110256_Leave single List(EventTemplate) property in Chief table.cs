using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SchedulerMigrations.Migrations
{
    public partial class LeavesingleListEventTemplatepropertyinChieftable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SingleEvent_Chief_ChiefId1",
                table: "SingleEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyEvent_Chief_ChiefId1",
                table: "WeeklyEvent");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyEvent_ChiefId1",
                table: "WeeklyEvent");

            migrationBuilder.DropIndex(
                name: "IX_SingleEvent_ChiefId1",
                table: "SingleEvent");

            migrationBuilder.DropColumn(
                name: "ChiefId1",
                table: "WeeklyEvent");

            migrationBuilder.DropColumn(
                name: "ChiefId1",
                table: "SingleEvent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChiefId1",
                table: "WeeklyEvent",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChiefId1",
                table: "SingleEvent",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyEvent_ChiefId1",
                table: "WeeklyEvent",
                column: "ChiefId1");

            migrationBuilder.CreateIndex(
                name: "IX_SingleEvent_ChiefId1",
                table: "SingleEvent",
                column: "ChiefId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SingleEvent_Chief_ChiefId1",
                table: "SingleEvent",
                column: "ChiefId1",
                principalTable: "Chief",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyEvent_Chief_ChiefId1",
                table: "WeeklyEvent",
                column: "ChiefId1",
                principalTable: "Chief",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
