using AutoMapper;
using Chat.Domain.Common;
using Chat.Domain.Mensagens.Dtos;
using Chat.Domain.Mensagens.Entidades;
using Chat.Domain.Mensagens.Interfaces;
using Chat.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Infra.Data.Consultas
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
            var calculoPaginacao = ((pagina - 1) * filtro.TotalPorPagina) 
                + (filtro.PrimeiraBusca ? 0 : filtro.QtdMensagensPular);

            var totalPorPagina = filtro.TotalPorPagina 
                + (filtro.PrimeiraBusca ? filtro.QtdMensagensPular : 0);

            IQueryable<Mensagem> mensagens = CriarConsultaDeMensagens(filtro);

            retorno.Pagina = pagina;
            retorno.TotalPorPagina = totalPorPagina;
            retorno.Total = mensagens.Count();
            retorno.Lista = Mapper.Map<List<MensagemDto>>(mensagens
                    .Skip(calculoPaginacao)
                    .Take(totalPorPagina))
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
