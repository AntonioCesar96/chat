using System.Threading.Tasks;
using Chat.Application.Conversas.Interfaces;
using Chat.Domain.Conversas.Interfaces;

namespace Chat.Application.ListaContato
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
