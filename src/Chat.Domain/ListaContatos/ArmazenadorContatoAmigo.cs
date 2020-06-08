using Chat.Domain.Contatos.Interfaces;
using Chat.Domain.ListaContatos.Dto;
using Chat.Domain.ListaContatos.Entities;
using Chat.Domain.ListaContatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.ListaContatos
{
    public class ArmazenadorContatoAmigo : IArmazenadorContatoAmigo
    {
        private readonly IListaContatoRepositorio _listaContatoRepositorio;
        private readonly IContatoRepositorio _contatoRepositorio;

        public ArmazenadorContatoAmigo(
            IListaContatoRepositorio listaContatoRepositorio,
            IContatoRepositorio contatoRepositorio)
        {
            _listaContatoRepositorio = listaContatoRepositorio;
            _contatoRepositorio = contatoRepositorio;
        }

        public async Task<int> Salvar(ContatoAmigoCriacaoDto dto)
        {
            var contato = _contatoRepositorio.ObterPorEmail(dto.EmailAmigo);
            if(contato == null)
                return 0;

            var entity = new ListaContato(dto.ContatoPrincipalId, contato.Id);
            await _listaContatoRepositorio.Salvar(entity);

            return entity.Id;
        }
    }
}
