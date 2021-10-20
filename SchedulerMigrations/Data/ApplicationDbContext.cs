using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SchedulerModels;

namespace SchedulerMigrations.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SchedulerModels.Chief> Chief { get; set; }
        public DbSet<SchedulerModels.Event> Event { get; set; }
    }
}
