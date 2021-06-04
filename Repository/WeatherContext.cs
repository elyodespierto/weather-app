using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Repository
{
    public class WeatherContext : DbContext
    {
        public WeatherContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherHistoryItem> WeatherHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherHistoryItem>().ToTable("WeatherHistory");
            modelBuilder.Entity<City>().ToTable("Cities");
        }
    }
}
