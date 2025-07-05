using Confy.Abstractions.Types;
using Confy.Application.Notifications;
using Confy.Domain.Repositories;
using Confy.Domain.Users.Events;
using MediatR;

namespace Confy.Application.Auth.Handlers
{
    internal sealed class UserCreatedHandler(
        IUserRepository userRepository,
        IEmailSenderService emailSender) : INotificationHandler<UserCreated>
    {
        public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            var userId = AggregateId.Create(notification.UserId);
            var user = await userRepository.GetAsync(userId);

            if (user is not null)
                await emailSender.SendConfirmation(user.Email, user.ConfirmationToken);
        }
    }
}
