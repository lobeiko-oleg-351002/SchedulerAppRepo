using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerMigrations.Migrations
{
    public partial class InitScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChiefId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_EventTemplate_Id",
                        column: x => x.Id,
                        principalTable: "EventTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SingleEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChiefId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleEvent_Event_Id",
                        column: x => x.Id,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChiefId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chief",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chief", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chief_Student_Id",
                        column: x => x.Id,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriber_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriber_Student_Id",
                        column: x => x.Id,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChiefId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyEvent_Chief_ChiefId1",
                        column: x => x.ChiefId1,
                        principalTable: "Chief",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyEvent_Event_Id",
                        column: x => x.Id,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyEventTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeeklyEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyEventTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyEventTime_WeeklyEvent_WeeklyEventId",
                        column: x => x.WeeklyEventId,
                        principalTable: "WeeklyEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayOfWeek",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeeklyEventTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfWeek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOfWeek_WeeklyEventTime_WeeklyEventTimeId",
                        column: x => x.WeeklyEventTimeId,
                        principalTable: "WeeklyEventTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayOfWeek_WeeklyEventTimeId",
                table: "DayOfWeek",
                column: "WeeklyEventTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTemplate_ChiefId",
                table: "EventTemplate",
                column: "ChiefId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleEvent_ChiefId1",
                table: "SingleEvent",
                column: "ChiefId1");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ChiefId",
                table: "Student",
                column: "ChiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriber_EventId",
                table: "Subscriber",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyEvent_ChiefId1",
                table: "WeeklyEvent",
                column: "ChiefId1");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyEventTime_WeeklyEventId",
                table: "WeeklyEventTime",
                column: "WeeklyEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTemplate_Chief_ChiefId",
                table: "EventTemplate",
                column: "ChiefId",
                principalTable: "Chief",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleEvent_Chief_ChiefId1",
                table: "SingleEvent",
                column: "ChiefId1",
                principalTable: "Chief",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Chief_ChiefId",
                table: "Student",
                column: "ChiefId",
                principalTable: "Chief",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chief_Student_Id",
                table: "Chief");

            migrationBuilder.DropTable(
                name: "DayOfWeek");

            migrationBuilder.DropTable(
                name: "SingleEvent");

            migrationBuilder.DropTable(
                name: "Subscriber");

            migrationBuilder.DropTable(
                name: "WeeklyEventTime");

            migrationBuilder.DropTable(
                name: "WeeklyEvent");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "EventTemplate");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Chief");
        }
    }
}
