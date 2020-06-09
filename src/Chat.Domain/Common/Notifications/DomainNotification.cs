using Chat.Domain.Common.Events;

namespace Chat.Domain.Common.Notifications
{
    public class DomainNotification : Event
    {
        public string Key { get; }
        public string Value { get; }

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
