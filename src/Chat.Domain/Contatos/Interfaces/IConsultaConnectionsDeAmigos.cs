using System.Collections.Generic;

namespace Chat.Domain.Contatos.Interfaces
{
    public interface IConsultaConnectionsDeAmigos
    {
        List<string> Consultar(int contatoId);
    }
}
