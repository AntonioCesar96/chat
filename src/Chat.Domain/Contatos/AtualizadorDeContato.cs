using Chat.Domain.Common;
using Chat.Domain.Common.Interfaces;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Dtos;
using Chat.Domain.Contatos.Entidades;
using Chat.Domain.Contatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos
{
    public class AtualizadorDeContato : DomainService, IAtualizadorDeContato
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public AtualizadorDeContato(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IContatoRepositorio contatoRepositorio,
            IUnitOfWork unitOfWork) : base(notificacaoDeDominio)
        {
            _contatoRepositorio = contatoRepositorio;
            _unitOfWork = unitOfWork;
        }

        public async Task<Contato> Atualizar(ContatoDto dto)
        {
            Contato contato = _contatoRepositorio.ObterPorId(dto.ContatoId);

            AtualizarDadosDoContato(dto, contato);
            await _unitOfWork.Commit();

            return contato;
        }

        private void AtualizarDadosDoContato(ContatoDto dto, Contato contato)
        {
            contato.AlterarNome(dto.Nome);
            contato.AlterarDescricao(dto.Descricao);            
        }
    }
}
