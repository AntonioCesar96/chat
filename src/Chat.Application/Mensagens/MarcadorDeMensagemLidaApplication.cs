using System.Threading.Tasks;
using Chat.Application.Mensagens.Interfaces;
using Chat.Domain.Mensagens.Interfaces;

namespace Chat.Application.Mensagens
{
    public class MarcadorDeMensagemLidaApplication : IMarcadorDeMensagemLidaApplication
    {
        private readonly IMarcadorDeMensagemLida _marcadorDeMensagemLida;

        public MarcadorDeMensagemLidaApplication(IMarcadorDeMensagemLida marcadorDeMensagemLida)
        {
            _marcadorDeMensagemLida = marcadorDeMensagemLida;
        }

        public async Task MarcarMensagemComoLida(int conversaId, int mensagemId)
        {
            await _marcadorDeMensagemLida.MarcarMensagemComoLida(conversaId, mensagemId);
        }
    }
}
