using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Interfaces;
using Chat.Infra.Util.AutoMapper;
using System.Threading.Tasks;

namespace Chat.Application.Contatos
{
    public class AtualizadorDeContatoStatusApplication : IAtualizadorDeContatoStatusApplication
    {
        private readonly IAtualizadorDeContatoStatus _atualizadorDeContatoStatus;

        public AtualizadorDeContatoStatusApplication(
            IAtualizadorDeContatoStatus atualizadorDeContatoStatus)
        {
            _atualizadorDeContatoStatus = atualizadorDeContatoStatus;
        }

        public async Task<ContatoStatusDto> AtualizarParaOffline(string connectionId)
        {
            var contatoStatus = await _atualizadorDeContatoStatus.AtualizarParaOffline(connectionId);
            return contatoStatus.MapTo<ContatoStatusDto>();
        }
    }
}
