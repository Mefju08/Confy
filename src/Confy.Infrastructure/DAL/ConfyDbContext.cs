using Confy.Abstractions.Types;
using Confy.Domain.Abstractions;
using Confy.Domain.Reservations;
using Confy.Domain.Rooms;
using Confy.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.DAL
{
    internal sealed class ConfyDbContext : DbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public ConfyDbContext(DbContextOptions<ConfyDbContext> options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entitiesWithEvents = ChangeTracker.Entries<AggregateRoot>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.DomainEvents.ToArray();
                entity.ClearDomainEvents();

                foreach (var domainEvent in events)
                {
                    await _publisher.Publish(domainEvent, cancellationToken);
                }
            }

            return result;
        }
    }
}
