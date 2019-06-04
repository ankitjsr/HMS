﻿using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Data
{
    public class HMSContext : DbContext
    {
        public HMSContext() : base("HMSConnection")
        {
        }

        public DbSet<AccomodationType> AccomodationTypes { get; set; }
        public DbSet<AccomodationPackage> AccomodationPackages { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
    }
}