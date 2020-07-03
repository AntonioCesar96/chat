using Chat.Application.ContatosStatus.Interfaces;
using Chat.Domain.ContatosStatus.Interfaces;
using System.Collections.Generic;

namespace Chat.Application.ContatosStatus
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
