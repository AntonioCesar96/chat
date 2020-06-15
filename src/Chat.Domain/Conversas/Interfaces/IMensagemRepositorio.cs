using Chat.Domain.Conversas.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Domain.Conversas.Interfaces
{
    public interface IMensagemRepositorio
    {
        Task Salvar(Mensagem entity);
        List<Mensagem> ObterMensagensNaoLidasPorConversa(int conversaId);
        List<Mensagem> ObterMensagensNaoLidas(int conversaId, int mensagemId);
    }
}
