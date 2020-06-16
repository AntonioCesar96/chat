using Chat.Domain.ListaContatos.Dtos;
using System.Threading.Tasks;

namespace Chat.Application.ListaContato.Interfaces
{
    public interface IArmazenadorContatoAmigoApplication
    {
        Task<ListaContatoDto> Salvar(ContatoAmigoCriacaoDto dto);
    }
}
