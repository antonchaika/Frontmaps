using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DemoRealtApp.DAL.Models;

namespace DemoRealtApp.DAL.Context
{
    public class MapsContext : DbContext
    {
        public MapsContext() : base("MapsContext") { }
        public DbSet<GeoObject> GeoObjects { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<GeoObject>().Property(x => x.Latitude).HasPrecision(7, 5);
            modelBuilder.Entity<GeoObject>().Property(x => x.Longitude).HasPrecision(8, 5);*/
        }
    }
}