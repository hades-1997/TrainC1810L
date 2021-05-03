﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainC1810L.Models;
using TrainC1810L.Models.ModelView;

namespace TrainC1810L.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Station> stations { get; set; }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Train> trains { get; set; }
        public DbSet<Railway> Railway { get; set; }
        public DbSet<TrainRoute> TrainRoute { get; set; }
        public DbSet<Compartment> compartments { get; set; }
        public DbSet<Chair> chairs { get; set; }
        public DbSet<BookingTicket> bookingTickets { get; set; }
        public DbSet<Bill> Bill { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<TrainC1810L.Models.ModelView.Books> Books { get; set; }


        

    }
}
