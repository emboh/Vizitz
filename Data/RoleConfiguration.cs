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
                    Id = new Guid("b6f768d5-6d77-4814-8a93-a679f97b6448"),
                    Name = Role.Administrator,
                    NormalizedName = Role.Administrator.ToUpper(),
                    ConcurrencyStamp = "b6f768d5-6d77-4814-8a93-a679f97b6448",
                },
                new Role
                {
                    Id = new Guid("1fe125cd-2a32-4a6e-aed9-7ff821627b38"),
                    Name = Role.Proprietor,
                    NormalizedName = Role.Proprietor.ToUpper(),
                    ConcurrencyStamp = "1fe125cd-2a32-4a6e-aed9-7ff821627b38",
                },
                new Role
                {
                    Id = new Guid("889ef87a-ba2c-4e6e-b71c-03786981e437"),
                    Name = Role.Visitor,
                    NormalizedName = Role.Visitor.ToUpper(),
                    ConcurrencyStamp = "889ef87a-ba2c-4e6e-b71c-03786981e437",
                }
            );
        }
    }
}
