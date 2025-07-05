using Confy.Application.Security;
using Confy.Domain.Clock;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Confy.Infrastructure.DAL.Seeders
{
    internal sealed class SeedetHostedService(
        IPasswordManager passwordManager,
        IServiceProvider serviceProvider,
        IClock clock) : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ConfyDbContext>();
            await SeedService.Seed(dbContext, passwordManager, clock);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
