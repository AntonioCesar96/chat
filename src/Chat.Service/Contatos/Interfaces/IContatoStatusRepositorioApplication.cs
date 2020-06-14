using Chat.Domain.Conversas.Dto;
using System.Collections.Generic;

namespace Chat.Application.Contatos.Interfaces
{
    public interface IContatoStatusRepositorioApplication
    {
        List<string> ObterConnectionsIdsPorContatosIds(MensagemDto dto);
        List<string> ObterConnectionsIdsPorContatosIds(int contatoId);
    }
}
