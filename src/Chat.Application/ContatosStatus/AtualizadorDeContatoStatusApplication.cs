using AutoMapper;
using Chat.Application.ContatosStatus.Interfaces;
using Chat.Domain.ContatosStatus.Dtos;
using Chat.Domain.ContatosStatus.Interfaces;
using System.Threading.Tasks;

namespace Chat.Application.ContatosStatus
{
    public class AtualizadorDeContatoStatusApplication : IAtualizadorDeContatoStatusApplication
    {
        private readonly IAtualizadorDeContatoStatus _atualizadorDeContatoStatus;
        private readonly IMapper _mapper;

        public AtualizadorDeContatoStatusApplication(
            IAtualizadorDeContatoStatus atualizadorDeContatoStatus,
            IMapper mapper)
        {
            _atualizadorDeContatoStatus = atualizadorDeContatoStatus;
            _mapper = mapper;
        }

        public async Task<ContatoStatusDto> AtualizarParaOffline(string connectionId)
        {
            var contatoStatus = await _atualizadorDeContatoStatus.AtualizarParaOffline(connectionId);
            return _mapper.Map<ContatoStatusDto>(contatoStatus);
        }
    }
}
