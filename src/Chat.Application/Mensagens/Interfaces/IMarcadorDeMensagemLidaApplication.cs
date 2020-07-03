using System.Threading.Tasks;

namespace Chat.Application.Mensagens.Interfaces
{
    public interface IMarcadorDeMensagemLidaApplication
    {
        Task MarcarMensagemComoLida(int conversaId, int mensagemId);
    }
}
