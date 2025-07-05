using Confy.Application.ContextAccessor;
using Confy.Application.Notifications;
using Confy.Application.Security;
using Confy.Domain.Clock;
using Confy.Domain.Users;
using Confy.Infrastructure.Auth;
using Confy.Infrastructure.ContextAccessor;
using Confy.Infrastructure.DAL;
using Confy.Infrastructure.Exceptions;
using Confy.Infrastructure.Exceptions.Mappers;
using Confy.Infrastructure.Loggers;
using Confy.Infrastructure.Notifications;
using Confy.Infrastructure.Security;
using Confy.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

[assembly: InternalsVisibleTo("Confy.Api")]
namespace Confy.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructue(this IServiceCollection services,
            IConfiguration configuration)
        {
            var assembly = typeof(ConfyDbContext).Assembly;

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDal(configuration);
            services.AddAuth(configuration);

            services.AddMediatR(configuration =>
            {
                var appLayerAssemlby = typeof(IPasswordManager).Assembly;
                configuration.RegisterServicesFromAssemblies(assembly, appLayerAssemlby);
            });

            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddSingleton<IPasswordManager, PasswordManager>();

            services.AddScoped<LoggerMiddleware>();
            services.AddScoped<ExceptionHandlerMiddleware>();
            services.AddScoped<IExceptionToErrorMapper, ExceptionToErrorMapper>();

            services.AddHttpContextAccessor();
            services.AddScoped<IUserContext, UserContext>();

            services.AddSingleton<IEmailSenderService, EmailSenderService>();
            services.AddSingleton<IClock, Clock>();
            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<LoggerMiddleware>();
            app.UseAuth();
            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            return app;
        }

        public static WebApplicationBuilder BuildInfrastructure(this WebApplicationBuilder builder)
        {
            LogManager.Setup()
                .LoadConfigurationFromFile("nlog.config")
                .GetCurrentClassLogger();

            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            return builder;
        }
    }
}
