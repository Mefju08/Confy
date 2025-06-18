using Confy.Domain.Reservations;
using Confy.Domain.Rooms;
using Confy.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.DAL
{
    internal sealed class ConfyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public ConfyDbContext(DbContextOptions<ConfyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
