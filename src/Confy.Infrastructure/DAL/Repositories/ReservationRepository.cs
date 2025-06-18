using Confy.Domain.Repositories;
using Confy.Domain.Reservations;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.DAL.Repositories
{
    internal sealed class ReservationRepository(
        ConfyDbContext db) : IReservationRepository
    {
        public Task<Reservation> GetAsync(int id)
           => db.Reservations.Where(x => x.Id == id)
            .Include(x => x.Room)
            .SingleOrDefaultAsync();

        public async Task<int> AddAsync(Reservation reservation)
        {
            await db.Reservations.AddAsync(reservation);
            await db.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            db.Reservations.Update(reservation);
            await db.SaveChangesAsync();
        }
    }
}
