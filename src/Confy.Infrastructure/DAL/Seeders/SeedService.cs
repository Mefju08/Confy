using Confy.Application.Security;
using Confy.Domain.Clock;
using Confy.Domain.Reservations;
using Confy.Domain.Reservations.ValueObjects;
using Confy.Domain.Rooms;
using Confy.Domain.Rooms.ValueObjects;
using Confy.Domain.Users;
using Confy.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.DAL.Seeders
{
    internal static class SeedService
    {
        public static async Task Seed(ConfyDbContext db, IPasswordManager passwordManager, IClock clock)
        {
            if (db.Database.GetPendingMigrations().Any())
            {
                await db.Database.MigrateAsync();
            }


            if (!await db.Users.AnyAsync())
            {
                var user1 = User.Create(
                    email: Email.Create("user1@example.com"),
                    fullName: FullName.Create("Jan Kowalski"),
                    password: Password.Create(passwordManager.Hash("hashed-password-121!")));

                var user2 = User.Create(
                    email: Email.Create("admin@example.com"),
                    fullName: FullName.Create("Anna Nowak"),
                    password: Password.Create(passwordManager.Hash("hashed-password-32121!")));

                user2.PromoteToAdmin();

                db.Users.AddRange(user1, user2);
                await db.SaveChangesAsync();
            }

            if (!await db.Rooms.AnyAsync())
            {
                var room1 = Room.Create(
                    RoomName.Create("Sala A"),
                    RoomCapacity.Create(10),
                    RoomLocation.Create("Parter"),
                    RoomDescription.Create("Sala konferencyjna"));

                var room2 = Room.Create(
                    RoomName.Create("Sala B"),
                    RoomCapacity.Create(5),
                    RoomLocation.Create("1 piętro"),
                    RoomDescription.Create("Pokój spotkań"));

                db.Rooms.AddRange(room1, room2);
                await db.SaveChangesAsync();
            }

            if (!await db.Reservations.AnyAsync())
            {
                var user = await db.Users.FirstAsync();
                var room = await db.Rooms.FirstAsync();

                var reservation = Reservation.Create(
                    roomId: room.Id,
                    userId: user.Id,
                    DateRange.Create(clock.Now().AddHours(3), clock.Now().AddHours(5), clock.Now()));

                db.Reservations.Add(reservation);
                await db.SaveChangesAsync();
            }

        }
    }
}
