using Confy.Domain.Reservations;

namespace Confy.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task<int> AddAsync(Reservation reservation);
        Task<Reservation> GetAsync(int id);
        Task UpdateAsync(Reservation reservation);
    }
}