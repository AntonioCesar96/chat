using Chat.Domain.ContatosStatus.Dtos;
using Chat.Domain.Mensagens.Dtos;
using System.Collections.Generic;

namespace Chat.Application.ContatosStatus.Interfaces
{
    public interface IContatoStatusRepositorioApplication
    {
        List<string> ObterConnectionsIdsPorContatosIds(MensagemDto dto);
        List<string> ObterConnectionsIdsPorContatosIds(int contatoId);
        ContatoStatusDto ObterPorContato(int contatoId);
    }
}
