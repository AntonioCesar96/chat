using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Entities;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IArmazenadorDeContato
    {
        Task<Contato> Salvar(ContatoDto dto);
    }
}
