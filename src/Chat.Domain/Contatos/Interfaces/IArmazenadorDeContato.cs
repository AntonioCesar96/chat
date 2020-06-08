using Chat.Domain.Contatos.Dto;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IArmazenadorDeContato
    {
        Task<int> Salvar(ContatoDto dto);
    }
}
