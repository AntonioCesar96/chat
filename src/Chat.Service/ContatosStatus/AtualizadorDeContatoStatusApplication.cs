using Chat.Application.ContatosStatus.Interfaces;
using Chat.Domain.ContatosStatus.Dtos;
using Chat.Domain.ContatosStatus.Interfaces;
using Chat.Infra.Util.AutoMapper;
using System.Threading.Tasks;

namespace Chat.Application.ContatosStatus
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
