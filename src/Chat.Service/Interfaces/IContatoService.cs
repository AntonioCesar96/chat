using Chat.Domain.Common;
using Chat.Domain.Contatos.Dto;
using Chat.Domain.ListaContatos.Dto;
using System.Threading.Tasks;

namespace Chat.Service.Interfaces
{
    public interface IContatoService
    {
        Task<int> Salvar(ContatoDto dto);
        ResultadoDaConsulta ObterListaDeContatos(ListaContatoFiltroDto filtro);
    }
}
