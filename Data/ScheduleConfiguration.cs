using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vizitz.Entities;

namespace Vizitz.Data
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
