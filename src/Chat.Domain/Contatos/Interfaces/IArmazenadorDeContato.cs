using Chat.Domain.Contatos.Dtos;
using Chat.Domain.Contatos.Entidades;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IArmazenadorDeContato
    {
        Task<Contato> Salvar(ContatoCriacaoDto dto);
    }
}
