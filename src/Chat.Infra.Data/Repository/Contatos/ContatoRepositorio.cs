﻿using Chat.Domain.Contatos.Entities;
using Chat.Domain.Contatos.Interfaces;
using Chat.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repository.Contatos
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
    }
}
