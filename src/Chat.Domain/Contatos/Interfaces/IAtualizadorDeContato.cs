using Chat.Domain.Contatos.Dtos;
using Chat.Domain.Contatos.Entidades;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IAtualizadorDeContato
    {
        Task<Contato> Atualizar(ContatoDto dto);
    }
}
