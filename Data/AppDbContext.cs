using LicenseApp.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace LicenseApp.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Sakhan> Sakhans { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<LicenseItem> LicenseItems { get; set; }
        
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Gate> Gates { get; set; }

    }
    /* public class AppDbContext : DbContext
     {
         public DbSet<Application> Applications { get; set; }
         public DbSet<LicenseItem> LicenseItems { get; set; }
         public DbSet<Sakhan> Sakhans { get; set; }
         public DbSet<Item> Items { get; set; }
         public DbSet<Unit> Units { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Application>()
                 .HasMany(a => a.LicenseItems)
                 .WithOne(li => li.Application)
                 .HasForeignKey(li => li.ApplicationId);

             modelBuilder.Entity<LicenseItem>()
                 .HasOne(li => li.Item)
                 .WithMany()
                 .HasForeignKey(li => li.ItemId);

             modelBuilder.Entity<LicenseItem>()
                 .HasOne(li => li.Unit)
                 .WithMany()
                 .HasForeignKey(li => li.UnitId);
         }
     }*/


}

