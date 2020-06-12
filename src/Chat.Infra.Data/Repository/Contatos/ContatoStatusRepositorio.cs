using Chat.Domain.Contatos.Entities;
using Chat.Domain.Contatos.Interfaces;
using Chat.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repository.Contatos
{
    public class ContatoStatusRepositorio : IContatoStatusRepositorio
    {
        private readonly ChatDbContext _dbContext;

        public ContatoStatusRepositorio(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Salvar(ContatoStatus contatoStatus)
        {
            _dbContext.Add(contatoStatus);
            await _dbContext.SaveChangesAsync();
        }

        public ContatoStatus ObterPorContato(int contatoId)
        {
            return _dbContext.Set<ContatoStatus>()
                .FirstOrDefault(x => x.ContatoId == contatoId);
        }

        public List<string> ObterConnectionsIdsPorContatosIds(List<int> contatosIds)
        {
            return _dbContext.Set<ContatoStatus>()
                .Where(x => contatosIds.Any(id => id == x.ContatoId))
                .Select(x => x.ConnectionId)
                .ToList();
        }

        public ContatoStatus ObterPorConnection(string connectionId)
        {
            return _dbContext.Set<ContatoStatus>()
                .FirstOrDefault(x => x.ConnectionId == connectionId);
        }

        public async Task RemoverPorConnection(string connectionId)
        {
            if (string.IsNullOrEmpty(connectionId)) return;

            var contatoStatus = ObterPorConnection(connectionId);
            if (contatoStatus == null) return;

            _dbContext.Remove(contatoStatus);
            await _dbContext.SaveChangesAsync();
        }
    }
}
