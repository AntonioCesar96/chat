using Chat.Domain.Conversas.Entities;
using Chat.Domain.Conversas.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Conversas
{
    public class ArmazenadorDeConversa : IArmazenadorDeConversa
    {
        private readonly IConversaRepositorio _conversaRepositorio;

        public ArmazenadorDeConversa(IConversaRepositorio conversaRepositorio)
        {
            _conversaRepositorio = conversaRepositorio;
        }

        public async Task<Conversa> Salvar(int contatoRemetenteId, int contatoDestinatarioId)
        {
            var entity = new Conversa(contatoRemetenteId, contatoDestinatarioId);
            await _conversaRepositorio.Salvar(entity);

            return entity;
        }
    }
}
