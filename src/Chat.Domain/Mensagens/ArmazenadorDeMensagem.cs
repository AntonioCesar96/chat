using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Mensagens.Dtos;
using Chat.Domain.Conversas.Interfaces;
using System.Threading.Tasks;
using Chat.Domain.Mensagens.Interfaces;
using Chat.Domain.Mensagens.Entidades;
using Chat.Domain.Conversas.Entidades;

namespace Chat.Domain.Mensagens
{
    public class ArmazenadorDeMensagem : DomainService, IArmazenadorDeMensagem
    {
        private readonly IConversaRepositorio _conversaRepositorio;
        private readonly IMensagemRepositorio _mensagemRepositorio;
        private readonly IArmazenadorDeConversa _armazenadorDeConversa;

        public ArmazenadorDeMensagem(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IConversaRepositorio conversaRepositorio,
            IArmazenadorDeConversa armazenadorDeConversa,
            IMensagemRepositorio mensagemRepositorio) : base(notificacaoDeDominio)
        {
            _conversaRepositorio = conversaRepositorio;
            _armazenadorDeConversa = armazenadorDeConversa;
            _mensagemRepositorio = mensagemRepositorio;
        }

        public async Task<Mensagem> Salvar(MensagemDto dto)
        {
            var conversa = await ObterOuCriarConversaSeNaoExistir(dto);
            if (_notificacaoDeDominio.HasNotifications()) return null;

            Mensagem mensagem = CriarMensagem(dto, conversa);
            if (!await ValidarSeMensagemEstaValido(mensagem)) return null;

            await _mensagemRepositorio.Salvar(mensagem);

            if(dto.ConversaId == 0)
                mensagem = _mensagemRepositorio.ObterPorId(mensagem.Id);

            return mensagem;
        }

        private static Mensagem CriarMensagem(MensagemDto dto, Conversa conversa)
        {
            return new Mensagem(conversa.Id, dto.ContatoRemetenteId,
                dto.ContatoDestinatarioId, dto.MensagemEnviada);
        }

        private async Task<Conversa> ObterOuCriarConversaSeNaoExistir(MensagemDto dto)
        {
            var conversa = _conversaRepositorio.ObterPorId(dto.ConversaId);
            if (conversa == null)
                return await _armazenadorDeConversa.Salvar(dto.ContatoRemetenteId, dto.ContatoDestinatarioId);

            return conversa;
        }

        private async Task<bool> ValidarSeMensagemEstaValido(Mensagem mensagem)
        {
            if (mensagem.Validar()) return true;

            await NotificarValidacoesDeDominio(mensagem.ValidationResult);
            return false;
        }
    }
}
