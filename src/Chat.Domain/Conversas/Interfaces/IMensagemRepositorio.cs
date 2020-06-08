using Chat.Domain.Conversas.Entities;
using System.Threading.Tasks;

namespace Chat.Domain.Conversas.Interfaces
{
    public interface IMensagemRepositorio
    {
        Task Salvar(Mensagem entity);
    }
}
