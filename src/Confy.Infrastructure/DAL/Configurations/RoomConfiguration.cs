using Confy.Abstractions.Types;
using Confy.Domain.Rooms;
using Confy.Domain.Rooms.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confy.Infrastructure.DAL.Configurations
{
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, y => AggregateId.Create(y))
                .IsRequired();

            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, y => RoomName.Create(y))
                .IsRequired();

            builder.Property(x => x.Capacity)
                .HasConversion(x => x.Value, y => RoomCapacity.Create(y))
                .IsRequired();

            builder.Property(x => x.Location)
                .HasConversion(x => x.Value, y => RoomLocation.Create(y))
                .IsRequired();

            builder.Property(x => x.Description)
                .HasConversion(x => x.Value, y => RoomDescription.Create(y))
                .IsRequired();
        }
    }
}
