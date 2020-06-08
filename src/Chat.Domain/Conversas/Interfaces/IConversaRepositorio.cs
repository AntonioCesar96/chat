using Chat.Domain.Conversas.Entities;
using System.Threading.Tasks;

namespace Chat.Domain.Conversas.Interfaces
{
    public interface IConversaRepositorio
    {
        Task Salvar(Conversa conversa);
        Conversa ObterPorId(int conversaId);
    }
}
