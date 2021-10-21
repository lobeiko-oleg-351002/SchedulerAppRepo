using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerMigrations.Migrations
{
    public partial class Initialseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DayOfWeek",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a20f009f-c7a2-41c3-b975-fea70be55d89"), "Monday" },
                    { new Guid("d5350a05-2b79-42dc-ba57-bc4f9c1b33ac"), "Tuesday" },
                    { new Guid("6e4685a4-8745-44d4-abba-e8272b6a1894"), "Wednesday" },
                    { new Guid("c62897d0-9e2a-4249-bccd-fe976e5a57fb"), "Thursday" },
                    { new Guid("6a668739-2109-4117-a0db-b18dd13577f1"), "Friday" },
                    { new Guid("16dd7964-9272-4943-a75c-40fd66ee268a"), "Saturday" },
                    { new Guid("e2581347-520c-442e-94ad-919669203084"), "Sunday" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("bd6d6b50-fdb4-4aa2-91e7-1072bf6312e4"), "totalit280@gmail.com", "Totalit", "vitebsk2021" },
                    { new Guid("20e220d5-25d1-4a83-9197-2210cd55dfaa"), "mlarsm@gmail.com", "Lars Ulrich", "drumdrum" },
                    { new Guid("b23cf592-7c89-485d-b1fd-a746f7c5a3a7"), "normandy@gmail.com", "John", "shepard2072" },
                    { new Guid("801be765-0711-4a51-81ec-633982fa5ac3"), "eugene@gmail.com", "Raynor", "raiders44" }
                });

            migrationBuilder.InsertData(
                table: "Chief",
                columns: new[] { "Id", "Profile" },
                values: new object[] { new Guid("bd6d6b50-fdb4-4aa2-91e7-1072bf6312e4"), "Discussion Club" });

            migrationBuilder.InsertData(
                table: "Chief",
                columns: new[] { "Id", "Profile" },
                values: new object[] { new Guid("20e220d5-25d1-4a83-9197-2210cd55dfaa"), "Drum Club" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chief",
                keyColumn: "Id",
                keyValue: new Guid("20e220d5-25d1-4a83-9197-2210cd55dfaa"));

            migrationBuilder.DeleteData(
                table: "Chief",
                keyColumn: "Id",
                keyValue: new Guid("bd6d6b50-fdb4-4aa2-91e7-1072bf6312e4"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("16dd7964-9272-4943-a75c-40fd66ee268a"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("6a668739-2109-4117-a0db-b18dd13577f1"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("6e4685a4-8745-44d4-abba-e8272b6a1894"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("a20f009f-c7a2-41c3-b975-fea70be55d89"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("c62897d0-9e2a-4249-bccd-fe976e5a57fb"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("d5350a05-2b79-42dc-ba57-bc4f9c1b33ac"));

            migrationBuilder.DeleteData(
                table: "DayOfWeek",
                keyColumn: "Id",
                keyValue: new Guid("e2581347-520c-442e-94ad-919669203084"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("801be765-0711-4a51-81ec-633982fa5ac3"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("b23cf592-7c89-485d-b1fd-a746f7c5a3a7"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("20e220d5-25d1-4a83-9197-2210cd55dfaa"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("bd6d6b50-fdb4-4aa2-91e7-1072bf6312e4"));
        }
    }
}
