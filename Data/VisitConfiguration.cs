using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vizitz.Entities;

namespace Vizitz.Data
{
    public class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
