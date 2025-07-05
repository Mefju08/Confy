using Confy.Application.Notifications;

namespace Confy.Infrastructure.Notifications
{
    internal sealed class EmailSenderService : IEmailSenderService
    {
        public async Task SendConfirmation(string email, string token)
        {
            await Task.CompletedTask;
        }
    }
}
