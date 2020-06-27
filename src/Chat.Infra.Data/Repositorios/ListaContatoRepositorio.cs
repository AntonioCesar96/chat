using Chat.Domain.ListaContatos.Entidades;
using Chat.Domain.ListaContatos.Interfaces;
using Chat.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repositorios
{
    public class ListaContatoRepositorio : IListaContatoRepositorio
    {
        private readonly ChatDbContext _dbContext;

        public ListaContatoRepositorio(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Salvar(ListaContato listaContato)
        {
            _dbContext.Add(listaContato);
            await _dbContext.SaveChangesAsync();
        }

        public ListaContato ObterPorListaContato(ListaContato listaContato)
        {
            return _dbContext.Set<ListaContato>()
                .FirstOrDefault(x => x.ContatoPrincipalId == listaContato.ContatoPrincipalId
                    && x.ContatoAmigoId == listaContato.ContatoAmigoId);
        }
    }
}
