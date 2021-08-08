using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Vizitz.Entities;

namespace Vizitz.Data
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.HasData(
                new Role
                {
                    Id = new Guid(Role.AdministratorId),
                    Name = Role.Administrator,
                    NormalizedName = Role.Administrator.ToUpper(),
                    ConcurrencyStamp = Role.AdministratorId,
                },
                new Role
                {
                    Id = new Guid(Role.ProprietorId),
                    Name = Role.Proprietor,
                    NormalizedName = Role.Proprietor.ToUpper(),
                    ConcurrencyStamp = Role.ProprietorId,
                },
                new Role
                {
                    Id = new Guid(Role.VisitorId),
                    Name = Role.Visitor,
                    NormalizedName = Role.Visitor.ToUpper(),
                    ConcurrencyStamp = Role.VisitorId,
                }
            );
        }
    }
}
