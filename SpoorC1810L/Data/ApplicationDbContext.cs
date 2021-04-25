using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpoorC1810L.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TrainC1810L.Models;

namespace SpoorC1810L.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Station> stations { get; set; }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Fare> fares { get; set; }
       public DbSet<Train> trains { get; set; }
        public DbSet<Compartment> compartments { get; set; }
        public DbSet<Chair> chairs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<SpoorC1810L.Models.Railway> Railway { get; set; }
        public DbSet<SpoorC1810L.Models.TrainRoute> TrainRoute { get; set; }
        

    }
}
