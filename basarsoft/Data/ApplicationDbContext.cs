using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basarsoft.Controllers;
using basarsoft.Data;
using basarsoft.Interfaces;
// using basarsoft.Migrations;
using basarsoft.Models;
using basarsoft.Services;
using basarsoft.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace basarsoft.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Coordinates> Coordinates { get; set; }
        public DbSet<Todo> Todo { get; set; }
        // public DbSet<Items> Items { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);

        //     modelBuilder.Entity<Coordinates>().ToTable("Coordinate");
        //     modelBuilder.Entity<Coordinates>().Property(c => c.XCoordinate).HasColumnName("XCoordinate");
        //     modelBuilder.Entity<Coordinates>().Property(c => c.YCoordinate).HasColumnName("YCoordinate");
        //     modelBuilder.Entity<Coordinates>().Property(c => c.Name).HasColumnName("Name");
        // }
    }
}