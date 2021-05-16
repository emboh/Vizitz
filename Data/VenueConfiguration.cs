using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vizitz.Entities;

namespace Vizitz.Data
{
    public class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.HasQueryFilter(q => q.Deleted == null);
        }
    }
}
