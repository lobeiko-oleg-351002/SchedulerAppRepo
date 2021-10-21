using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SchedulerMigrations.Migrations
{
    public partial class FixSubscriberPart2ManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Subscriber",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriber_StudentId",
                table: "Subscriber",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriber_Student_StudentId",
                table: "Subscriber",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriber_Student_StudentId",
                table: "Subscriber");

            migrationBuilder.DropIndex(
                name: "IX_Subscriber_StudentId",
                table: "Subscriber");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Subscriber");
        }
    }
}
