using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Contatos.Interfaces;
using System.Collections.Generic;

namespace Chat.Application.Contatos
{
    public class ConsultaConnectionsDeAmigosApplication : IConsultaConnectionsDeAmigosApplication
    {
        private readonly IConsultaConnectionsDeAmigos _consultaContatoStatusDeAmigos;

        public ConsultaConnectionsDeAmigosApplication(
            IConsultaConnectionsDeAmigos consultaContatoStatusDeAmigos)
        {
            _consultaContatoStatusDeAmigos = consultaContatoStatusDeAmigos;
        }

        public List<string> Consultar(int contatoId)
        {
            return _consultaContatoStatusDeAmigos.Consultar(contatoId);
        }
    }
}
