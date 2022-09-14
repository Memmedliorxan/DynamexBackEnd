using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasIndex(e => e.PassportFIN).IsUnique(true);
            });
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasIndex(e => e.PassportNumber).IsUnique(true);
            });
            builder.ApplyConfiguration(new AccountConfiguration());
            base.OnModelCreating(builder);
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Filial> Filials { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Addresses> Addresses { get; set; } 

    }
}
