using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Entities;
using Chat.Domain.Contatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos
{
    public class ValidadorDeContato : DomainService, IValidadorDeContato
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ValidadorDeContato(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IContatoRepositorio contatoRepositorio) : base(notificacaoDeDominio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public async Task<bool> ValidarDominio(Contato contato)
        {
            if (contato.Validar()) return true;

            await NotificarValidacoesDeDominio(contato.ValidationResult);
            return false;
        }

        public async Task<bool> ValidarSeEmailJaExiste(string email)
        {
            var contato = _contatoRepositorio.ObterPorEmail(email);
            if (contato == null) return false;

            await NotificarErroDeDominio(ChatResources.MsgJaExisteUmaContaComEsseEmail);
            return true;
        }

        public async Task<bool> ValidarEmail(string email)
        {
            if (!string.IsNullOrEmpty(email) && EmailHelper.Validar(email)) return true;

            await NotificarErroDeDominio(ChatResources.MsgEmailInvalido);
            return false;
        }

        public async Task<bool> ValidarSenha(string senha)
        {
            if (!string.IsNullOrEmpty(senha) && senha.Length >= 6 && senha.Length <= 10)
                return true;

            await NotificarErroDeDominio(ChatResources.MsgSenhaEntreSeisDezCaracteres);
            return false;
        }

        public async Task<bool> ValidarSeContatoDiferenteDeNulo(Contato contato, string msg)
        {
            if (contato != null) return true;

            await NotificarErroDeDominio(msg);
            return false;
        }
    }
}
