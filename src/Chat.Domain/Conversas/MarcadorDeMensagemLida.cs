using Chat.Domain.Common;
using Chat.Domain.Common.Interfaces;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Conversas.Enums;
using Chat.Domain.Conversas.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Conversas
{
    public class MarcadorDeMensagemLida : DomainService, IMarcadorDeMensagemLida
    {
        private readonly IMensagemRepositorio _mensagemRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public MarcadorDeMensagemLida(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IMensagemRepositorio mensagemRepositorio,
            IUnitOfWork unitOfWork) : base(notificacaoDeDominio)
        {
            _mensagemRepositorio = mensagemRepositorio;
            _unitOfWork = unitOfWork;
        }

        public async Task MarcarMensagemComoLida(int conversaId, int mensagemId)
        {
            var mensagens = _mensagemRepositorio.ObterMensagensNaoLidas(conversaId, mensagemId);

            mensagens.ForEach(x => x.AlterarStatusMensagem(StatusMensagem.Lida));

            await _unitOfWork.Commit();
        }
    }
}
