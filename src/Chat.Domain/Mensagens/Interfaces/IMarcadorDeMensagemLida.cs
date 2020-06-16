using System.Threading.Tasks;

namespace Chat.Domain.Mensagens.Interfaces
{
    public interface IMarcadorDeMensagemLida
    {
        Task MarcarMensagemComoLida(int conversaId, int mensagemId);
    }
}
