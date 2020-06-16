using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Entidades;
using Chat.Domain.Contatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos
{
    public class AutenticacaoContato : DomainService, IAutenticacaoContato
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly IValidadorDeContato _validadorDeContato;

        public AutenticacaoContato(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IContatoRepositorio contatoRepositorio,
            IValidadorDeContato validadorDeContato) : base(notificacaoDeDominio)
        {
            _contatoRepositorio = contatoRepositorio;
            _validadorDeContato = validadorDeContato;
        }

        public async Task<Contato> Autenticar(string email, string senha)
        {
            var contato = _contatoRepositorio.ObterPorEmail(email);
            if(!await _validadorDeContato.ValidarSeContatoDiferenteDeNulo(contato, 
                ChatResources.MsgNaoEmailNaoEncontrado))
                return null;

            contato = _contatoRepositorio.ObterPorEmailSenha(email, senha);
            if (!await _validadorDeContato.ValidarSeContatoDiferenteDeNulo(contato, 
                ChatResources.MsgSenhaInvalida))
                return null;

            contato.LimparSenha();
            return contato;
        }
    }
}
