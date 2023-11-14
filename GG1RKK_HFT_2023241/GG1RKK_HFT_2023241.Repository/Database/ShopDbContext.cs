using GG1RKK_HFT_202324.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GG1RKK_HFT_2023241.Repository.Database
{
    internal class ShopDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ShopDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("shop");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(item => item
                .HasOne<Manufacturer>()
                .WithMany()
                .HasForeignKey(item => item.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade));



        }
    }
}
