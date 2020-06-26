using Chat.Domain.ContatosStatus.Entidades;
using Chat.Domain.ContatosStatus.Interfaces;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repositorios
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

        public async Task Atualizar(ContatoStatus contatoStatus)
        {
            _dbContext.Update(contatoStatus);
            await _dbContext.SaveChangesAsync();
        }

        public ContatoStatus ObterPorContato(int contatoId)
        {
            return _dbContext.Set<ContatoStatus>()
                .Include(x => x.Contato)
                .FirstOrDefault(x => x.ContatoId == contatoId);
        }

        public IQueryable<ContatoStatus> ObterPorContatosIds(List<int> contatosIds)
        {
            return _dbContext.Set<ContatoStatus>()
                .Where(x => contatosIds.Any(id => id == x.ContatoId));
        }

        public List<string> ObterConnectionsIdsPorContatosIds(List<int> contatosIds)
        {
            return ObterPorContatosIds(contatosIds)
                .Select(x => x.ConnectionId)
                .ToList();
        }

        public ContatoStatus ObterPorConnection(string connectionId)
        {
            return _dbContext.Set<ContatoStatus>()
                .Include(x => x.Contato)
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

        public async Task RemoverPorContato(int contatoId)
        {
            var contatos = ObterPorContatosIds(new List<int>() { contatoId });
            if (!contatos.Any()) return;

            _dbContext.RemoveRange(contatos);
            await _dbContext.SaveChangesAsync();
        }
    }
}
