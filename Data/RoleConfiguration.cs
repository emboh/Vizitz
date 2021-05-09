using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Vizitz.Data
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.HasData(
                new IdentityRole<Guid>
                { 
                    Id = new Guid("b6f768d5-6d77-4814-8a93-a679f97b6448"),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    ConcurrencyStamp = "b6f768d5-6d77-4814-8a93-a679f97b6448",
                },
                new IdentityRole<Guid>
                {
                    Id = new Guid("1fe125cd-2a32-4a6e-aed9-7ff821627b38"),
                    Name = "Proprietor",
                    NormalizedName = "PROPRIETOR",
                    ConcurrencyStamp = "1fe125cd-2a32-4a6e-aed9-7ff821627b38",
                },
                new IdentityRole<Guid>
                {
                    Id = new Guid("889ef87a-ba2c-4e6e-b71c-03786981e437"),
                    Name = "Visitor",
                    NormalizedName = "VISITOR",
                    ConcurrencyStamp = "889ef87a-ba2c-4e6e-b71c-03786981e437",
                }
            );
        }
    }
}
