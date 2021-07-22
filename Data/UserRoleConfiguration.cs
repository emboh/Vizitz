using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vizitz.Entities;

namespace Vizitz.Data
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(e => e.User)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            builder.HasOne(e => e.Role)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(u => u.RoleId)
                .IsRequired();
        }
    }
}