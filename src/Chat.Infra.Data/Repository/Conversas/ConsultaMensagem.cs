using AutoMapper;
using Chat.Domain.Common;
using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Entities;
using Chat.Domain.Conversas.Interfaces;
using Chat.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Infra.Data.Repository.Conversas
{
    public class ConsultaMensagem : IConsultaMensagem
    {
        private readonly ChatDbContext _dbContext;

        public ConsultaMensagem(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResultadoDaConsulta ObterMensagens(MensagemFiltroDto filtro)
        {
            var retorno = new ResultadoDaConsulta();

            var pagina = filtro.Pagina > 0 ? filtro.Pagina : 1;
            var calculoPaginacao = ((pagina - 1) * filtro.TotalPorPagina) + filtro.QtdMensagensPular;

            IQueryable<Mensagem> mensagens = CriarConsultaDeMensagens(filtro);

            retorno.Pagina = pagina;
            retorno.TotalPorPagina = filtro.TotalPorPagina;
            retorno.Total = mensagens.Count();
            retorno.Lista = Mapper.Map<List<MensagemDto>>(mensagens
                    .Skip(calculoPaginacao)
                    .Take(filtro.TotalPorPagina))
                    .OrderBy(x => x.DataEnvio);

            return retorno;
        }

        private IQueryable<Mensagem> CriarConsultaDeMensagens(MensagemFiltroDto filtro)
        {
            return _dbContext.Set<Mensagem>()
                .OrderByDescending(x => x.DataEnvio)
                .Where(p => p.ConversaId == filtro.ConversaId);
        }
    }
}
