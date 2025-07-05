using Confy.Domain.Abstractions;
using Confy.Domain.Repositories;
using Confy.Infrastructure.DAL.Options;
using Confy.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Confy.Infrastructure.DAL
{
    internal static class Extensions
    {
        public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
        {
            var dbOptions = new DbOptions();
            configuration.GetRequiredSection(DbOptions.SectionName).Bind(dbOptions);

            services.AddDbContext<ConfyDbContext>(options =>
            {
                options.UseSqlServer(dbOptions.ConnectionString);
            });
            services.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<ConfyDbContext>());

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            //services.AddHostedService<SeedetHostedService>();

            return services;
        }
    }
}
