using Chat.Domain.Contatos.Entidades;
using Chat.Domain.Contatos.Interfaces;
using Chat.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repositorios
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly ChatDbContext _dbContext;

        public ContatoRepositorio(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Salvar(Contato contato)
        {
            _dbContext.Add(contato);
            await _dbContext.SaveChangesAsync();
        }

        public Contato ObterPorEmail(string email)
        {
            return _dbContext.Set<Contato>()
                .FirstOrDefault(x => x.Email == email.Trim().ToLower());
        }

        public Contato ObterPorId(int id)
        {
            return _dbContext.Set<Contato>()
                .FirstOrDefault(x => x.Id == id);
        }

        public Contato ObterPorEmailSenha(string email, string senha)
        {
            return _dbContext.Set<Contato>()
                .FirstOrDefault(x => x.Email == email.Trim().ToLower() 
                    && x.Senha == senha.Trim().ToLower());
        }
    }
}
