using System.Collections.Generic;

namespace Chat.Application.Contatos.Interfaces
{
    public interface IConsultaConnectionsDeAmigosApplication
    {
        List<string> Consultar(int contatoId);
    }
}
