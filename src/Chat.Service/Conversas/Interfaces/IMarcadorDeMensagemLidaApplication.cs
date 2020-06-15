using System.Threading.Tasks;

namespace Chat.Application.Conversas.Interfaces
{
    public interface IMarcadorDeMensagemLidaApplication
    {
        Task MarcarMensagemComoLida(int conversaId, int mensagemId);
    }
}
