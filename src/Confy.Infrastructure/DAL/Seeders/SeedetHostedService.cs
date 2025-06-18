using Confy.Application.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Confy.Infrastructure.DAL.Seeders
{
    internal sealed class SeedetHostedService(
        IPasswordManager passwordManager,
        IServiceProvider serviceProvider) : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ConfyDbContext>();
            await SeedService.Seed(dbContext, passwordManager);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
