using Chat.Domain.ListaContatos.Dto;
using System.Threading.Tasks;

namespace Chat.Domain.ListaContatos.Interfaces
{
    public interface IArmazenadorContatoAmigo
    {
        Task<int> Salvar(ContatoAmigoCriacaoDto dto);
    }
}
