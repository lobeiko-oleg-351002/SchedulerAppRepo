using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerMigrations.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chief",
                keyColumn: "Id",
                keyValue: new Guid("5ce9045b-ccd6-4dbd-9afe-aabd5706de03"));

            migrationBuilder.DeleteData(
                table: "Chief",
                keyColumn: "Id",
                keyValue: new Guid("7db454ca-6345-4d17-a630-fa725e612b07"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("1a4571de-c60c-44d2-8caa-688704fbaefd"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("6164bcfb-31f0-42c7-a6b7-1324aefd150b"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("72245cae-9fbe-439a-a073-2e83736a1d26"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("97e766e6-c8b0-49c8-81b8-42b736ac3b56"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("99063a5d-b63a-4e6b-b3a4-f0765b34a65c"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("c177818c-ec63-4ce6-a8c9-725da08fdc46"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("c9d300a6-dc45-4e03-945f-a36c949874ce"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("55d6a505-6d48-4dd4-9cf4-0bef15761ca1"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("75057fa2-84ce-4f20-b411-f3405ccd9b0d"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("5ce9045b-ccd6-4dbd-9afe-aabd5706de03"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("7db454ca-6345-4d17-a630-fa725e612b07"));

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DayOfWeek",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ec51a38b-6e66-495e-8d06-521968615219"), "Monday" },
                    { new Guid("8d658792-fd18-43ae-83dc-cc590deafe6e"), "Tuesday" },
                    { new Guid("316a7b38-b201-43ad-bcda-97e471afd7b9"), "Wednesday" },
                    { new Guid("6e024dd4-3bb2-4950-aa86-89a690e1f6ae"), "Thursday" },
                    { new Guid("2d452b7c-1fc7-4177-95db-54ea33a48551"), "Friday" },
                    { new Guid("9560f26d-e357-49b2-9bb8-d015cfac0a99"), "Saturday" },
                    { new Guid("d876720f-172c-4197-a8b3-80ab4b73e278"), "Sunday" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9d0c63ea-1c81-4918-aa9e-4ae46d145263"), "Admin" },
                    { new Guid("5c83a1ff-21e9-4153-bf52-94d68a375bd6"), "User" }
                });

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Student",
                type: "uniqueidentifier",
                defaultValue : "5c83a1ff-21e9-4153-bf52-94d68a375bd6",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Student_RoleId",
                table: "Student",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Role_RoleId",
                table: "Student",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { new Guid("80688d76-3197-407d-bc61-69f6aedce3cb"), "totalit280@gmail.com", "Totalit", "vitebsk2021", "5c83a1ff-21e9-4153-bf52-94d68a375bd6" },
                    { new Guid("dbf823ae-0aef-4307-b215-c18892309f01"), "mlarsm@gmail.com", "Lars Ulrich", "drumdrum", "5c83a1ff-21e9-4153-bf52-94d68a375bd6" },
                    { new Guid("bd7a8d3f-b18f-4107-8cd7-b02b61c8a452"), "normandy@gmail.com", "John", "shepard2072", "5c83a1ff-21e9-4153-bf52-94d68a375bd6" },
                    { new Guid("091ac8de-5614-423c-aac5-36fced77cd94"), "eugene@gmail.com", "Raynor", "raiders44", "5c83a1ff-21e9-4153-bf52-94d68a375bd6" }
                });

            migrationBuilder.InsertData(
                table: "Chief",
                columns: new[] { "Id", "Profile" },
                values: new object[] { new Guid("80688d76-3197-407d-bc61-69f6aedce3cb"), "Discussion Club" });

            migrationBuilder.InsertData(
                table: "Chief",
                columns: new[] { "Id", "Profile" },
                values: new object[] { new Guid("dbf823ae-0aef-4307-b215-c18892309f01"), "Drum Club" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Role_RoleId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Student_RoleId",
                table: "Student");

            migrationBuilder.DeleteData(
                table: "Chief",
                keyColumn: "Id",
                keyValue: new Guid("80688d76-3197-407d-bc61-69f6aedce3cb"));

            migrationBuilder.DeleteData(
                table: "Chief",
                keyColumn: "Id",
                keyValue: new Guid("dbf823ae-0aef-4307-b215-c18892309f01"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("2d452b7c-1fc7-4177-95db-54ea33a48551"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("316a7b38-b201-43ad-bcda-97e471afd7b9"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("6e024dd4-3bb2-4950-aa86-89a690e1f6ae"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("8d658792-fd18-43ae-83dc-cc590deafe6e"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("9560f26d-e357-49b2-9bb8-d015cfac0a99"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("d876720f-172c-4197-a8b3-80ab4b73e278"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("ec51a38b-6e66-495e-8d06-521968615219"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("091ac8de-5614-423c-aac5-36fced77cd94"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("bd7a8d3f-b18f-4107-8cd7-b02b61c8a452"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("80688d76-3197-407d-bc61-69f6aedce3cb"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("dbf823ae-0aef-4307-b215-c18892309f01"));

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Student");

            migrationBuilder.InsertData(
                table: "DayOfWeek",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c177818c-ec63-4ce6-a8c9-725da08fdc46"), "Monday" },
                    { new Guid("6164bcfb-31f0-42c7-a6b7-1324aefd150b"), "Tuesday" },
                    { new Guid("c9d300a6-dc45-4e03-945f-a36c949874ce"), "Wednesday" },
                    { new Guid("97e766e6-c8b0-49c8-81b8-42b736ac3b56"), "Thursday" },
                    { new Guid("99063a5d-b63a-4e6b-b3a4-f0765b34a65c"), "Friday" },
                    { new Guid("72245cae-9fbe-439a-a073-2e83736a1d26"), "Saturday" },
                    { new Guid("1a4571de-c60c-44d2-8caa-688704fbaefd"), "Sunday" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("7db454ca-6345-4d17-a630-fa725e612b07"), "totalit280@gmail.com", "Totalit", "vitebsk2021" },
                    { new Guid("5ce9045b-ccd6-4dbd-9afe-aabd5706de03"), "mlarsm@gmail.com", "Lars Ulrich", "drumdrum" },
                    { new Guid("55d6a505-6d48-4dd4-9cf4-0bef15761ca1"), "normandy@gmail.com", "John", "shepard2072" },
                    { new Guid("75057fa2-84ce-4f20-b411-f3405ccd9b0d"), "eugene@gmail.com", "Raynor", "raiders44" }
                });

            migrationBuilder.InsertData(
                table: "Chief",
                columns: new[] { "Id", "Profile" },
                values: new object[] { new Guid("7db454ca-6345-4d17-a630-fa725e612b07"), "Discussion Club" });

            migrationBuilder.InsertData(
                table: "Chief",
                columns: new[] { "Id", "Profile" },
                values: new object[] { new Guid("5ce9045b-ccd6-4dbd-9afe-aabd5706de03"), "Drum Club" });
        }
    }
}
