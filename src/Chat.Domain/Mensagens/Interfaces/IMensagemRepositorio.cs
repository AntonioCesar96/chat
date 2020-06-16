using Chat.Domain.Mensagens.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Domain.Mensagens.Interfaces
{
    public interface IMensagemRepositorio
    {
        Task Salvar(Mensagem mensagem);
        List<Mensagem> ObterMensagensNaoLidasPorConversa(int conversaId);
        List<Mensagem> ObterMensagensNaoLidas(int conversaId, int mensagemId);
    }
}
