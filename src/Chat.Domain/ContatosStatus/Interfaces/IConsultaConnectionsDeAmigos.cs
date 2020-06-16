using System.Collections.Generic;

namespace Chat.Domain.ContatosStatus.Interfaces
{
    public interface IConsultaConnectionsDeAmigos
    {
        List<string> Consultar(int contatoId);
    }
}
