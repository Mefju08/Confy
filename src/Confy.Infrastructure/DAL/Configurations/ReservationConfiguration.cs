using Confy.Abstractions.Types;
using Confy.Domain.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confy.Infrastructure.DAL.Configurations
{
    internal sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, y => AggregateId.Create(y))
                .IsRequired();

            builder.Property(x => x.RoomId)
                .HasConversion(x => x.Value, y => AggregateId.Create(y))
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasConversion(x => x.Value, y => AggregateId.Create(y))
                .IsRequired();

            builder.OwnsOne(r => r.Dates, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.Property(d => d.StartDate)
                    .HasColumnName("StartDate")
                    .IsRequired();

                ownedNavigationBuilder.Property(d => d.EndDate)
                    .HasColumnName("EndDate")
                    .IsRequired();
            });

            builder.Property(x => x.Status)
               .HasConversion<string>()
               .IsRequired();
        }
    }
}
