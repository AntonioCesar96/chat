using Chat.Domain.Conversas.Entities;
using Chat.Domain.Conversas.Enums;
using Chat.Domain.Conversas.Interfaces;
using Chat.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
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

        public List<Mensagem> ObterMensagensNaoLidasPorConversa(int conversaId)
        {
            return _dbContext.Set<Mensagem>()
                .Where(x => x.ConversaId == conversaId && x.StatusMensagem != StatusMensagem.Lida)
                .ToList();
        }

        public List<Mensagem> ObterMensagensNaoLidas(int conversaId, int mensagemId)
        {
            return _dbContext.Set<Mensagem>()
                .Where(x =>
                    (mensagemId != 0 && x.Id == mensagemId) || (mensagemId == 0 && x.ConversaId == conversaId)
                    && x.StatusMensagem != StatusMensagem.Lida)
                .ToList();
        }

        public async Task Salvar(Mensagem mensagem)
        {
            _dbContext.Add(mensagem);
            await _dbContext.SaveChangesAsync();
        }
    }
}