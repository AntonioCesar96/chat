using System.Collections.Generic;

namespace Chat.Application.ContatosStatus.Interfaces
{
    public interface IConsultaConnectionsDeAmigosApplication
    {
        List<string> Consultar(int contatoId);
    }
}
