using Chat.Domain.Mensagens.Dtos;
using Chat.Domain.Mensagens.Entidades;
using System.Threading.Tasks;

namespace Chat.Domain.Mensagens.Interfaces
{
    public interface IArmazenadorDeMensagem
    {
        Task<Mensagem> Salvar(MensagemDto dto);
    }
}
