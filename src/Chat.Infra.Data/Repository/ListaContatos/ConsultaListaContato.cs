using AutoMapper;
using Chat.Domain.Common;
using Chat.Domain.ListaContatos.Dto;
using Chat.Domain.ListaContatos.Entities;
using Chat.Domain.ListaContatos.Interfaces;
using Chat.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Infra.Data.Repository.ListaContatos
{
    public class ConsultaListaContato : IConsultaListaContato
    {
        private readonly ChatDbContext _dbContext;

        public ConsultaListaContato(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResultadoDaConsulta ObterContatosAmigos(ListaContatoFiltroDto filtro)
        {
            try
            {
                var retorno = new ResultadoDaConsulta();

                var pagina = filtro.Pagina > 0 ? filtro.Pagina : 1;
                var calculoPaginacao = (pagina - 1) * filtro.TotalPorPagina;

                var listaContatos = _dbContext.Set<ListaContato>()
                    .Where(p => p.ContatoAmigoId == filtro.ContatoPrincipalId);

                retorno.Pagina = pagina;
                retorno.TotalPorPagina = filtro.TotalPorPagina;
                retorno.Total = listaContatos.Count();
                retorno.Lista = Mapper.Map<List<ListaContatoDto>>(listaContatos
                        .Skip(calculoPaginacao)
                        .Take(filtro.TotalPorPagina));

                return retorno;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
