using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Entities;
using Chat.Domain.Contatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos
{
    public class ArmazenadorDeContato : DomainService, IArmazenadorDeContato
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ArmazenadorDeContato(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IContatoRepositorio contatoRepositorio) : base(notificacaoDeDominio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public async Task<Contato> Salvar(ContatoDto dto)
        {
            Contato contato = CriarContato(dto);

            if (!await ValidarSeContatoEstaValido(contato)) return null;

            await _contatoRepositorio.Salvar(contato);
            return contato;
        }

        private Contato CriarContato(ContatoDto dto)
        {
            return new Contato(dto.Nome, dto.Email, dto.Senha);
        }

        private async Task<bool> ValidarSeContatoEstaValido(Contato contato)
        {
            if(contato.Validar()) return true;

            await NotificarValidacoesDeDominio(contato.ValidationResult);
            return false;
        }
    }
}
