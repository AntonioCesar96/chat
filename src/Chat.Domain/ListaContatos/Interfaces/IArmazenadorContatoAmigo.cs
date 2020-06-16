using Chat.Domain.ListaContatos.Dtos;
using Chat.Domain.ListaContatos.Entidades;
using System.Threading.Tasks;

namespace Chat.Domain.ListaContatos.Interfaces
{
    public interface IArmazenadorContatoAmigo
    {
        Task<ListaContato> Salvar(ContatoAmigoCriacaoDto dto);
    }
}
