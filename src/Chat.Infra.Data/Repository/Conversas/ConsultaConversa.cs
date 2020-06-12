using Chat.Domain.Common;
using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Entities;
using Chat.Domain.Conversas.Interfaces;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Chat.Infra.Data.Repository.Conversas
{
    public class ConsultaConversa : IConsultaConversa
    {
        private readonly ChatDbContext _dbContext;

        public ConsultaConversa(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResultadoDaConsulta ObterConversasDoContato(ConversaFiltroDto filtro)
        {
            var retorno = new ResultadoDaConsulta();

            var pagina = filtro.Pagina > 0 ? filtro.Pagina : 1;
            var calculoPaginacao = (pagina - 1) * filtro.TotalPorPagina;

            IQueryable<UltimaConversaDto> conversas = CriarConsultaDeConversas(filtro);

            retorno.Pagina = pagina;
            retorno.TotalPorPagina = filtro.TotalPorPagina;
            retorno.Total = conversas.Count();
            retorno.Lista = conversas
                    .Skip(calculoPaginacao)
                    .Take(filtro.TotalPorPagina)
                    .ToList();

            return retorno;
        }

        private IQueryable<UltimaConversaDto> CriarConsultaDeConversas(ConversaFiltroDto filtro)
        {
            return (
                from conversa in _dbContext.Set<Conversa>()
                    .Include(x => x.ContatoCriadorDaConversaId)
                    .Include(x => x.Contato)
                    .Include(x => x.Mensagens)

                where conversa.ContatoCriadorDaConversaId == filtro.ContatoId
                    || conversa.ContatoId == filtro.ContatoId

                orderby conversa.Mensagens.OrderByDescending(x => x.DataEnvio).FirstOrDefault().DataEnvio descending

                select new UltimaConversaDto()
                {
                    ConversaId = conversa.Id,
                    UltimaMensagem = conversa.Mensagens.OrderByDescending(x => x.DataEnvio).FirstOrDefault().MensagemEnviada,
                    ContatoRemetenteId = conversa.Mensagens.OrderByDescending(x => x.DataEnvio).FirstOrDefault().ContatoRemetenteId,
                    DataEnvio = conversa.Mensagens.OrderByDescending(x => x.DataEnvio).FirstOrDefault().DataEnvio,
                    ContatoAmigoId = conversa.ContatoId == filtro.ContatoId ? conversa.ContatoCriadorDaConversaId : conversa.ContatoId,
                    Nome = conversa.ContatoId == filtro.ContatoId ? conversa.ContatoCriadorDaConversa.Nome : conversa.Contato.Nome,
                    Email = conversa.ContatoId == filtro.ContatoId ? conversa.ContatoCriadorDaConversa.Email : conversa.Contato.Email,
                    FotoUrl = conversa.ContatoId == filtro.ContatoId ? conversa.ContatoCriadorDaConversa.FotoUrl : conversa.Contato.FotoUrl,
                }
            );
        }
    }
}
