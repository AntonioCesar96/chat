using Chat.Domain.Conversas.Entities;
using Chat.Domain.Conversas.Interfaces;
using Chat.Infra.Data.Context;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repository.Conversas
{
    public class MensagemRepositorio : IMensagemRepositorio
    {
        private readonly ChatDbContext _dbContext;

        public MensagemRepositorio(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Salvar(Mensagem mensagem)
        {
            _dbContext.Add(mensagem);
            await _dbContext.SaveChangesAsync();
        }
    }
}