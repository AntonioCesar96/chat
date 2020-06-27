using Chat.Domain.Common;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Contatos.Entidades;
using Chat.Domain.Contatos.Interfaces;
using Chat.Domain.ListaContatos.Dtos;
using Chat.Domain.ListaContatos.Entidades;
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
            listaContato.AtribuirContatoAmigo(contato);

            return listaContato;
        }

        private ListaContato CriarListaContato(ContatoAmigoCriacaoDto dto, Contato contato)
        {
            return new ListaContato(dto.ContatoPrincipalId, contato.Id);
        }

        private async Task<bool> ValidarSeListaContatoEstaValido(ListaContato listaContato)
        {
            var listaContatoDuplicado =_listaContatoRepositorio.ObterPorListaContato(listaContato);
            if (listaContatoDuplicado == null) return true;

            await NotificarErroDeServico(ChatResources.MsgContatoJaAdicionadoComoAmigo);
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
