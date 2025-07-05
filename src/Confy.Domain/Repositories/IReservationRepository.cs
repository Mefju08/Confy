using Confy.Abstractions.Types;
using Confy.Domain.Reservations;
using Confy.Domain.Reservations.ValueObjects;

namespace Confy.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task AddAsync(Reservation reservation);
        Task<Reservation> GetAsync(AggregateId id);
        Task UpdateAsync(Reservation reservation);
        Task<bool> IsRoomAlreadyReservedAsync(AggregateId roomId, DateRange dates);
        Task<List<Reservation>> GetAllByUserIdAsync(AggregateId userId);
    }
}