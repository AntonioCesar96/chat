using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Dtos;
using Chat.Domain.Contatos.Entidades;
using Chat.Domain.Contatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos
{
    public class ArmazenadorDeContato : DomainService, IArmazenadorDeContato
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly IValidadorDeContato _validadorDeContato;

        public ArmazenadorDeContato(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IContatoRepositorio contatoRepositorio,
            IValidadorDeContato validadorDeContato) : base(notificacaoDeDominio)
        {
            _contatoRepositorio = contatoRepositorio;
            _validadorDeContato = validadorDeContato;
        }

        public async Task<Contato> Salvar(ContatoCriacaoDto dto)
        {
            Contato contato = CriarContato(dto);
            if (!await ValidarSeContatoEstaValido(contato)) return null;

            await _contatoRepositorio.Salvar(contato);
            return contato;
        }

        private Contato CriarContato(ContatoCriacaoDto dto)
        {
            return new Contato(dto.Nome, dto.Email, dto.Senha);
        }

        private async Task<bool> ValidarSeContatoEstaValido(Contato contato)
        {
            if(!await _validadorDeContato.ValidarDominio(contato)) return false;
            if (!await _validadorDeContato.ValidarEmail(contato.Email)) return false;
            if (!await _validadorDeContato.ValidarSenha(contato.Senha)) return false;
            if (await _validadorDeContato.ValidarSeEmailJaExiste(contato.Email)) return false;

            return true;
        }
    }
}
