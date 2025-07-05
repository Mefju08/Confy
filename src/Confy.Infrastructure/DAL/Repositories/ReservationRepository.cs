using Confy.Abstractions.Types;
using Confy.Domain.Repositories;
using Confy.Domain.Reservations;
using Confy.Domain.Reservations.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.DAL.Repositories
{
    internal sealed class ReservationRepository(
        ConfyDbContext db) : IReservationRepository
    {
        public Task<Reservation> GetAsync(AggregateId id)
        => db.Reservations.SingleOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Reservation reservation)
        {
            _ = db.Reservations.AddAsync(reservation);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            db.Reservations.Update(reservation);
            await Task.CompletedTask;
        }
        public Task<bool> IsRoomAlreadyReservedAsync(AggregateId roomId, DateRange dates)
            => db.Reservations
                .AnyAsync(r =>
                    r.RoomId == roomId &&
                    r.Status == ReservationStatus.Active &&
                    r.Dates.StartDate < dates.EndDate &&
                    r.Dates.EndDate > dates.StartDate);
        public Task<List<Reservation>> GetAllByUserIdAsync(AggregateId userId)
            => db.Reservations
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
}
