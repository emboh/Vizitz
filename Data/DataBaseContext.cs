using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Vizitz.Entities;
using Vizitz.IEntities;
using Vizitz.Models;

namespace Vizitz.Data
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            ChangeTracker.StateChanged += UpdateTimestamps;
            ChangeTracker.Tracked += UpdateTimestamps;
        }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Venue> Venues { get; set; }

        public DbSet<Visit> Visits { get; set; }

        private static void UpdateTimestamps(object sender, EntityEntryEventArgs e)
        {
            if (e.Entry.Entity is IHasTimestamps entityWithTimestamps)
            {
                switch (e.Entry.State)
                {
                    case EntityState.Deleted:
                        entityWithTimestamps.Deleted = DateTime.UtcNow;
                        Console.WriteLine($"Stamped for delete: {e.Entry.Entity}");
                        break;
                    case EntityState.Modified:
                        entityWithTimestamps.Modified = DateTime.UtcNow;
                        Console.WriteLine($"Stamped for update: {e.Entry.Entity}");
                        break;
                    case EntityState.Added:
                        entityWithTimestamps.Added = DateTime.UtcNow;
                        Console.WriteLine($"Stamped for insert: {e.Entry.Entity}");
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new VenueConfiguration());

            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());

            modelBuilder.ApplyConfiguration(new VenueConfiguration());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //var proprietors = new Faker<User>()
            //    .RuleFor(m => m.Id, f => Guid.NewGuid())
            //    .RuleFor(m => m.Name, f => f.Name.FullName())
            //    .RuleFor(m => m.Address, f => f.Address.FullAddress())
            //    .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber())
            //    .RuleFor(m => m.Email, f => f.Internet.Email())
            //    .RuleFor(m => m.IsActive, f => true)
            //    .RuleFor(m => m.Added, f => f.Date.Past())
            //    .RuleFor(m => m.Modified, f => f.Date.Recent());

            //modelBuilder
            //    .Entity<User>()
            //    .HasData(proprietors.GenerateBetween(10, 10));
        }
    }
}
