using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Entities;
using Chat.Domain.Contatos.Interfaces;
using Chat.Domain.ListaContatos.Dto;
using Chat.Domain.ListaContatos.Entities;
using Chat.Domain.ListaContatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.ListaContatos
{
    public class ArmazenadorContatoAmigo : DomainService, IArmazenadorContatoAmigo
    {
        private readonly IListaContatoRepositorio _listaContatoRepositorio;
        private readonly IContatoRepositorio _contatoRepositorio;

        public ArmazenadorContatoAmigo(
            IDomainNotificationHandlerAsync<DomainNotification> notificacaoDeDominio,
            IListaContatoRepositorio listaContatoRepositorio,
            IContatoRepositorio contatoRepositorio) : base(notificacaoDeDominio)
        {
            _listaContatoRepositorio = listaContatoRepositorio;
            _contatoRepositorio = contatoRepositorio;
        }

        public async Task<ListaContato> Salvar(ContatoAmigoCriacaoDto dto)
        {
            var contato = _contatoRepositorio.ObterPorEmail(dto.EmailAmigo);
            if (!await ValidarSeContatoExiste(contato)) return null;

            ListaContato listaContato = CriarListaContato(dto, contato);
            if (!await ValidarSeListaContatoEstaValido(listaContato)) return null;

            await _listaContatoRepositorio.Salvar(listaContato);
            return listaContato;
        }

        private ListaContato CriarListaContato(ContatoAmigoCriacaoDto dto, Contatos.Entities.Contato contato)
        {
            return new ListaContato(dto.ContatoPrincipalId, contato.Id);
        }

        private async Task<bool> ValidarSeListaContatoEstaValido(ListaContato listaContato)
        {
            if (listaContato.Validar()) return true;

            await NotificarValidacoesDeDominio(listaContato.ValidationResult);
            return false;
        }

        private async Task<bool> ValidarSeContatoExiste(Contato contato)
        {
            if (contato != null) return true;

            await NotificarErroDeServico(ChatResources.MsgContatoNaoEncontrado);
            return false;
        }
    }
}
