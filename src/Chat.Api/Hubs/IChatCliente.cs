using Chat.Domain.Common;
using Chat.Domain.ContatosStatus.Dtos;
using Chat.Domain.Mensagens.Dtos;
using System.Threading.Tasks;

namespace Chat.Api.Hubs
{
    public interface IChatCliente
    {
        Task Deslogar();
        Task ReceberStatusContatoOnline(int contatoId);
        Task ReceberStatusContatoOffline(ContatoStatusDto dto);
        Task ReceberMensagem(MensagemDto dto);
        Task ReceberContatoDigitando(bool estaDigitando, int contatoQueEstaDigitandoId);
        Task ReceberMensagemLida(int mensagemId, int conversaId);
        Task ReceberConversasDoContato(ResultadoDaConsulta resultado);
        Task ReceberMensagens(ResultadoDaConsulta resultado);
    }
}
