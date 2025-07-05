using Confy.Abstractions.Types;
using Confy.Domain.Users;
using Confy.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confy.Infrastructure.DAL.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, y => AggregateId.Create(y))
                 .IsRequired();

            builder.Property(x => x.Email).
                HasConversion(x => x.Value, y => Email.Create(y))
                .IsRequired();

            builder.Property(x => x.FullName)
                .HasConversion(x => x.Value, y => FullName.Create(y))
                .IsRequired();

            builder.Property(x => x.Password)
                .HasConversion(x => x.Value, y => Password.Create(y))
                .IsRequired();

            builder.Property(x => x.Role)
              .HasConversion<string>()
              .IsRequired();

            builder.Property(x => x.IsConfirmed)
                .IsRequired();

            builder.Property(x => x.ConfirmationToken)
                .HasConversion(x => x.Value, y => ConfirmationToken.Create(y))
                .IsRequired(false);

        }
    }
}
