using System.Threading.Tasks;

namespace MauiNotifications.Services.Publications
{
    public interface IPublicationService<T>
    {
        Task<PublishConfirmation> PublishMessageAsync(string topicName, T message, string subject);
    }
}