using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using Vizitz.Entities;
using Vizitz.Models;

namespace Vizitz.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext (DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<Schedule> Schedule { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Venue> Venue { get; set; }

        public DbSet<Visit> Visit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            var ids = 1;
            var proprietors = new Faker<ProprietorDTO>()
                .RuleFor(m => m.Id, f => ids++)
                .RuleFor(m => m.Name, f => f.Name.FullName())
                .RuleFor(m => m.Address, f => f.Address.FullAddress())
                .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(m => m.Email, f => f.Internet.Email())
                .RuleFor(m => m.IsActive, f => true);

            modelBuilder
                .Entity<ProprietorDTO>()
                .HasData(proprietors.GenerateBetween(10, 10));
        }
    }
}
