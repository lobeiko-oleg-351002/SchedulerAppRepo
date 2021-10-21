using Microsoft.EntityFrameworkCore;
using SchedulerModels;
using SchedulerModels.InitialSeed;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerMigrations.Data
{
    public class SchedulerDbContext : DbContext
    {
        public SchedulerDbContext(DbContextOptions<SchedulerDbContext> options) : base(options)
        {

        }

        public DbSet<Chief> Chiefs { get; set; }
        public DbSet<SchedulerModels.DayOfWeek> DaysOfWeek { get; set; }
        public DbSet<EventTemplate> EventTemplates { get; set; }
        public DbSet<SingleEvent> SingleEvents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<WeeklyEvent> WeeklyEvents { get; set; }
        public DbSet<WeeklyEventTime> WeeklyEventTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("SchedulerModels.EventTemplate", b =>
            {
                b.HasOne("SchedulerModels.Chief", null)
                    .WithMany("EventTemplates")
                    .HasForeignKey("ChiefId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("SchedulerModels.WeeklyEventTime", b =>
            {
                b.HasOne("SchedulerModels.WeeklyEvent", null)
                    .WithMany("DateAndTime")
                    .HasForeignKey("WeeklyEventId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.ApplyConfiguration(new DayOfWeekConfiguration());
            modelBuilder.ApplyConfiguration(new ChiefConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
    }
}

