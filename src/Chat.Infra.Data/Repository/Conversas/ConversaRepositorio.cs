using Chat.Domain.Conversas.Entities;
using Chat.Domain.Conversas.Interfaces;
using Chat.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repository.Conversas
{
    public class ConversaRepositorio : IConversaRepositorio
    {
        private readonly ChatDbContext _dbContext;

        public ConversaRepositorio(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Salvar(Conversa conversa)
        {
            _dbContext.Add(conversa);
            await _dbContext.SaveChangesAsync();
        }

        public Conversa ObterPorId(int conversaId)
        {
            return _dbContext.Set<Conversa>()
                .FirstOrDefault(x => x.Id == conversaId);
        }
    }
}