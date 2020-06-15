using System.Threading.Tasks;

namespace Chat.Domain.Conversas.Interfaces
{
    public interface IMarcadorDeMensagemLida
    {
        Task MarcarMensagemComoLida(int conversaId, int mensagemId);
    }
}
