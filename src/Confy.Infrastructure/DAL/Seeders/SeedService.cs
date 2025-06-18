using Confy.Application.Security;
using Confy.Domain.Reservations;
using Confy.Domain.Reservations.ValueObjects;
using Confy.Domain.Rooms;
using Confy.Domain.Users;
using Confy.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.DAL.Seeders
{
    internal static class SeedService
    {
        public static async Task Seed(ConfyDbContext db, IPasswordManager passwordManager)
        {
            if (db.Database.GetPendingMigrations().Any())
            {
                await db.Database.MigrateAsync();
            }


            if (!await db.Users.AnyAsync())
            {
                var user1 = new User(
                    email: "user1@example.com",
                    fullName: "Jan Kowalski",
                    passwordHash: passwordManager.Hash("hashed-password-121!"),
                    role: Role.User,
                    isConfirmed: true,
                    confirmationKey: Guid.NewGuid().ToString());

                var user2 = new User(
                    email: "admin@example.com",
                    fullName: "Anna Nowak",
                    passwordHash: passwordManager.Hash("hashed-password-32121!"),
                    role: Role.Admin,
                    isConfirmed: true,
                    confirmationKey: Guid.NewGuid().ToString());

                db.Users.AddRange(user1, user2);
                await db.SaveChangesAsync();
            }

            if (!await db.Rooms.AnyAsync())
            {
                var room1 = new Room("Sala A", 10, "Parter", "Sala konferencyjna");
                var room2 = new Room("Sala B", 5, "1 piętro", "Pokój spotkań");

                db.Rooms.AddRange(room1, room2);
                await db.SaveChangesAsync();
            }

            if (!await db.Reservations.AnyAsync())
            {
                var user = await db.Users.FirstAsync();
                var room = await db.Rooms.FirstAsync();

                var reservation = new Reservation(
                    roomId: room.Id,
                    userId: user.Id,
                    startDate: DateTime.UtcNow.AddHours(3),
                    endDate: DateTime.UtcNow.AddHours(5),
                    status: ReservationStatus.Active);

                db.Reservations.Add(reservation);
                await db.SaveChangesAsync();
            }

        }
    }
}
