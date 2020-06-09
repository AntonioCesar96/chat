using Chat.Domain.ListaContatos.Dto;
using Chat.Domain.ListaContatos.Entities;
using System.Threading.Tasks;

namespace Chat.Domain.ListaContatos.Interfaces
{
    public interface IArmazenadorContatoAmigo
    {
        Task<ListaContato> Salvar(ContatoAmigoCriacaoDto dto);
    }
}
