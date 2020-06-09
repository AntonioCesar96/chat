using System.Threading.Tasks;

namespace Chat.Domain.Common.Events
{
    public interface IHandlerAsync<in T> where T : Message
    {
        Task HandleAsync(T message);
    }
}
