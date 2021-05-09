using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vizitz.Entities;

namespace Vizitz.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
