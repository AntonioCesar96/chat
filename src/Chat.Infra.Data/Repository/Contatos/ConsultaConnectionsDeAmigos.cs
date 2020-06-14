using Chat.Domain.Contatos.Entities;
using Chat.Domain.Contatos.Interfaces;
using Chat.Domain.Conversas.Entities;
using Chat.Domain.ListaContatos.Entities;
using Chat.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Infra.Data.Repository.Contatos
{
    public class ConsultaConnectionsDeAmigos : IConsultaConnectionsDeAmigos
    {
        private readonly ChatDbContext _dbContext;

        public ConsultaConnectionsDeAmigos(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<string> Consultar(int contatoId)
        {
            List<string> connectionsIdsAmigos = ObterConnectionsIdsAmigos(contatoId);
            List<string> connectionsIdsConversas = ObterConnectionsIdsConversas(contatoId);

            return connectionsIdsAmigos.Concat(connectionsIdsConversas).Distinct().ToList();
        }

        private List<string> ObterConnectionsIdsAmigos(int contatoId)
        {
            return (
                from status in _dbContext.Set<ContatoStatus>()
                join listaContato in _dbContext.Set<ListaContato>()
                    on status.ContatoId equals listaContato.ContatoAmigoId

                where listaContato.ContatoPrincipalId == contatoId

                select status.ConnectionId
            ).ToList();
        }

        private List<string> ObterConnectionsIdsConversas(int contatoId)
        {
            return (
                from conversa in _dbContext.Set<Conversa>()

                join statusCriadorLeft in _dbContext.Set<ContatoStatus>()
                    on conversa.ContatoCriadorDaConversaId equals statusCriadorLeft.ContatoId into statusCriadorLeft
                from statusCriador in statusCriadorLeft.DefaultIfEmpty()

                join statusLeft in _dbContext.Set<ContatoStatus>()
                    on conversa.ContatoId equals statusLeft.ContatoId into statusLeft
                from status in statusLeft.DefaultIfEmpty()

                where conversa.ContatoCriadorDaConversaId == contatoId
                    || conversa.ContatoId == contatoId

                select conversa.ContatoId == contatoId
                        ? statusCriador.ConnectionId : status.ConnectionId
            ).ToList()
            .Where(connectionId => !string.IsNullOrEmpty(connectionId))
            .ToList();
        }
    }
}
