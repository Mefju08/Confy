namespace Confy.Application.Notifications
{
    public interface IEmailSenderService
    {
        Task SendConfirmation(string email, string token);
    }
}
