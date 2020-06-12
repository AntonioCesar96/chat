using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Interfaces;
using Chat.Infra.Util.AutoMapper;
using System.Threading.Tasks;

namespace Chat.Application.Contatos
{
    public class ArmazenadorDeContatoStatusApplication : IArmazenadorDeContatoStatusApplication
    {
        private readonly IArmazenadorDeContatoStatus _armazenadorDeContatoStatus;

        public ArmazenadorDeContatoStatusApplication(
            IArmazenadorDeContatoStatus armazenadorDeContatoStatus)
        {
            _armazenadorDeContatoStatus = armazenadorDeContatoStatus;
        }

        public async Task<ContatoStatusDto> Salvar(int contatoId, string connectionId)
        {
            var contatoStatus = await _armazenadorDeContatoStatus.Salvar(contatoId, connectionId);
            return contatoStatus.MapTo<ContatoStatusDto>();
        }
    }
}
