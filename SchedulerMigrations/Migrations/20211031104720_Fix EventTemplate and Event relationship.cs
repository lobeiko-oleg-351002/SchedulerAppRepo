using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerMigrations.Migrations
{
    public partial class FixEventTemplateandEventrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventTemplate_Id",
                table: "Event");

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

            migrationBuilder.AddColumn<Guid>(
                name: "ChiefId",
                table: "Event",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EventTemplateId",
                table: "Event",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Event_ChiefId",
                table: "Event",
                column: "ChiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTemplateId",
                table: "Event",
                column: "EventTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Chief_ChiefId",
                table: "Event",
                column: "ChiefId",
                principalTable: "Chief",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventTemplate_EventTemplateId",
                table: "Event",
                column: "EventTemplateId",
                principalTable: "EventTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Chief_ChiefId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventTemplate_EventTemplateId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_ChiefId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_EventTemplateId",
                table: "Event");

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

            migrationBuilder.DropColumn(
                name: "ChiefId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventTemplateId",
                table: "Event");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventTemplate_Id",
                table: "Event",
                column: "Id",
                principalTable: "EventTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
