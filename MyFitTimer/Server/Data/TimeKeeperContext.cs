using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFitTimer.Shared;

namespace MyFitTimer.Server.Data
{
    public class TimeKeeperContext : DbContext
    {
        public TimeKeeperContext(DbContextOptions<TimeKeeperContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        
        //seeder - not needed but for reference
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeKeeper>().HasData(
                new TimeKeeper { Id = 1, Time = 3000 },
                new TimeKeeper { Id = 2, Time = 63000 }
                );
        }*/

        public DbSet<Shared.TimeKeeper> TimeKeepers { get; set; }
        public DbSet<Shared.Stopwatcher> Stopwatchers { get; set; }
    }
}
