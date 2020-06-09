using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Entities;
using Chat.Domain.Contatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos
{
    public class AutenticacaoContato : DomainService, IAutenticacaoContato
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public AutenticacaoContato(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IContatoRepositorio contatoRepositorio) : base(notificacaoDeDominio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public async Task<Contato> Autenticar(string email, string senha)
        {
            var contato = _contatoRepositorio.ObterPorEmail(email);
            if(!await ValidarSeContatoFoiEncontrado(contato, ChatResources.MsgNaoEmailNaoEncontrado))
                return null;

            contato = _contatoRepositorio.ObterPorEmailSenha(email, senha);
            if (!await ValidarSeContatoFoiEncontrado(contato, ChatResources.MsgSenhaInvalida))
                return null;

            return contato;
        }

        private async Task<bool> ValidarSeContatoFoiEncontrado(Contato contato, string msg)
        {
            if (contato != null) return true;

            await NotificarErroDeServico(ChatResources.MsgSenhaInvalida);
            return false;
        }
    }
}
