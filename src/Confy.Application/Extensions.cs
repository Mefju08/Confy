using Confy.Application.Auth.Commands.Register;
using Confy.Application.Rooms.Policies;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Confy.Api")]
namespace Confy.Application
{
    internal static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(RegisterCommand).Assembly;
            services.AddValidatorsFromAssembly(assembly)
                .AddFluentValidationAutoValidation();

            services.AddScoped<IAddRoomPolicy, AddRoomPolicy>();
            return services;
        }
    }
}
