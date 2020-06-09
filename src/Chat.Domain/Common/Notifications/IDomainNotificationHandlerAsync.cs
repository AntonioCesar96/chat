using Chat.Domain.Common.Events;
using System.Collections.Generic;

namespace Chat.Domain.Common.Notifications
{
    public interface IDomainNotificationHandlerAsync<T> :
        IHandlerAsync<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
