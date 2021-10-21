﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchedulerMigrations.Data;

namespace SchedulerMigrations.Migrations
{
    [DbContext(typeof(SchedulerDbContext))]
    partial class SchedulerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChiefStudent", b =>
                {
                    b.Property<Guid>("ChiefsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChiefsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("ChiefStudent");
                });

            modelBuilder.Entity("DayOfWeekWeeklyEventTime", b =>
                {
                    b.Property<Guid>("DaysOfWeekId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WeeklyEventTimesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DaysOfWeekId", "WeeklyEventTimesId");

                    b.HasIndex("WeeklyEventTimesId");

                    b.ToTable("DayOfWeekWeeklyEventTime");
                });

            modelBuilder.Entity("SchedulerModels.DayOfWeek", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DayOfWeek");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a20f009f-c7a2-41c3-b975-fea70be55d89"),
                            Name = "Monday"
                        },
                        new
                        {
                            Id = new Guid("d5350a05-2b79-42dc-ba57-bc4f9c1b33ac"),
                            Name = "Tuesday"
                        },
                        new
                        {
                            Id = new Guid("6e4685a4-8745-44d4-abba-e8272b6a1894"),
                            Name = "Wednesday"
                        },
                        new
                        {
                            Id = new Guid("c62897d0-9e2a-4249-bccd-fe976e5a57fb"),
                            Name = "Thursday"
                        },
                        new
                        {
                            Id = new Guid("6a668739-2109-4117-a0db-b18dd13577f1"),
                            Name = "Friday"
                        },
                        new
                        {
                            Id = new Guid("16dd7964-9272-4943-a75c-40fd66ee268a"),
                            Name = "Saturday"
                        },
                        new
                        {
                            Id = new Guid("e2581347-520c-442e-94ad-919669203084"),
                            Name = "Sunday"
                        });
                });

            modelBuilder.Entity("SchedulerModels.EventTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChiefId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChiefId");

                    b.ToTable("EventTemplate");
                });

            modelBuilder.Entity("SchedulerModels.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b23cf592-7c89-485d-b1fd-a746f7c5a3a7"),
                            Email = "normandy@gmail.com",
                            Name = "John",
                            Password = "shepard2072"
                        },
                        new
                        {
                            Id = new Guid("801be765-0711-4a51-81ec-633982fa5ac3"),
                            Email = "eugene@gmail.com",
                            Name = "Raynor",
                            Password = "raiders44"
                        });
                });

            modelBuilder.Entity("SchedulerModels.Subscriber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("StudentId");

                    b.ToTable("Subscriber");
                });

            modelBuilder.Entity("SchedulerModels.WeeklyEventTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("WeeklyEventId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WeeklyEventId");

                    b.ToTable("WeeklyEventTime");
                });

            modelBuilder.Entity("SchedulerModels.Event", b =>
                {
                    b.HasBaseType("SchedulerModels.EventTemplate");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("SchedulerModels.Chief", b =>
                {
                    b.HasBaseType("SchedulerModels.Student");

                    b.Property<string>("Profile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Chief");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bd6d6b50-fdb4-4aa2-91e7-1072bf6312e4"),
                            Email = "totalit280@gmail.com",
                            Name = "Totalit",
                            Password = "vitebsk2021",
                            Profile = "Discussion Club"
                        },
                        new
                        {
                            Id = new Guid("20e220d5-25d1-4a83-9197-2210cd55dfaa"),
                            Email = "mlarsm@gmail.com",
                            Name = "Lars Ulrich",
                            Password = "drumdrum",
                            Profile = "Drum Club"
                        });
                });

            modelBuilder.Entity("SchedulerModels.SingleEvent", b =>
                {
                    b.HasBaseType("SchedulerModels.Event");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.ToTable("SingleEvent");
                });

            modelBuilder.Entity("SchedulerModels.WeeklyEvent", b =>
                {
                    b.HasBaseType("SchedulerModels.Event");

                    b.ToTable("WeeklyEvent");
                });

            modelBuilder.Entity("ChiefStudent", b =>
                {
                    b.HasOne("SchedulerModels.Chief", null)
                        .WithMany()
                        .HasForeignKey("ChiefsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchedulerModels.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DayOfWeekWeeklyEventTime", b =>
                {
                    b.HasOne("SchedulerModels.DayOfWeek", null)
                        .WithMany()
                        .HasForeignKey("DaysOfWeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchedulerModels.WeeklyEventTime", null)
                        .WithMany()
                        .HasForeignKey("WeeklyEventTimesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchedulerModels.EventTemplate", b =>
                {
                    b.HasOne("SchedulerModels.Chief", null)
                        .WithMany("EventTemplates")
                        .HasForeignKey("ChiefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulerModels.Subscriber", b =>
                {
                    b.HasOne("SchedulerModels.Event", "Event")
                        .WithMany("Subscribers")
                        .HasForeignKey("EventId");

                    b.HasOne("SchedulerModels.Student", "Student")
                        .WithMany("Subscribers")
                        .HasForeignKey("StudentId");

                    b.Navigation("Event");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchedulerModels.WeeklyEventTime", b =>
                {
                    b.HasOne("SchedulerModels.WeeklyEvent", null)
                        .WithMany("DateAndTime")
                        .HasForeignKey("WeeklyEventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulerModels.Event", b =>
                {
                    b.HasOne("SchedulerModels.EventTemplate", null)
                        .WithOne()
                        .HasForeignKey("SchedulerModels.Event", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchedulerModels.Chief", b =>
                {
                    b.HasOne("SchedulerModels.Student", null)
                        .WithOne()
                        .HasForeignKey("SchedulerModels.Chief", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchedulerModels.SingleEvent", b =>
                {
                    b.HasOne("SchedulerModels.Event", null)
                        .WithOne()
                        .HasForeignKey("SchedulerModels.SingleEvent", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchedulerModels.WeeklyEvent", b =>
                {
                    b.HasOne("SchedulerModels.Event", null)
                        .WithOne()
                        .HasForeignKey("SchedulerModels.WeeklyEvent", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchedulerModels.Student", b =>
                {
                    b.Navigation("Subscribers");
                });

            modelBuilder.Entity("SchedulerModels.Event", b =>
                {
                    b.Navigation("Subscribers");
                });

            modelBuilder.Entity("SchedulerModels.Chief", b =>
                {
                    b.Navigation("EventTemplates");
                });

            modelBuilder.Entity("SchedulerModels.WeeklyEvent", b =>
                {
                    b.Navigation("DateAndTime");
                });
#pragma warning restore 612, 618
        }
    }
}
