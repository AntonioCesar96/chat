using AutoMapper;
using Chat.Domain.Common;
using Chat.Domain.ListaContatos.Dto;
using Chat.Domain.ListaContatos.Entities;
using Chat.Domain.ListaContatos.Interfaces;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
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
            var retorno = new ResultadoDaConsulta();

            var pagina = filtro.Pagina > 0 ? filtro.Pagina : 1;
            var calculoPaginacao = (pagina - 1) * filtro.TotalPorPagina;

            var listaContatos = _dbContext.Set<ListaContato>()
                .Include(x => x.ContatoAmigo)
                .Where(p => 
                    p.ContatoPrincipalId == filtro.ContatoPrincipalId
                    && (string.IsNullOrEmpty(filtro.NomeAmigo) || p.ContatoAmigo.Nome.Contains(filtro.NomeAmigo.Trim().ToLower()))
                    && (string.IsNullOrEmpty(filtro.EmailAmigo) || p.ContatoAmigo.Email.Contains(filtro.EmailAmigo.Trim().ToLower()))
                );

            retorno.Pagina = pagina;
            retorno.TotalPorPagina = filtro.TotalPorPagina;
            retorno.Total = listaContatos.Count();
            retorno.Lista = Mapper.Map<List<ListaAmigosDto>>(listaContatos
                    .Skip(calculoPaginacao)
                    .Take(filtro.TotalPorPagina));

            return retorno;
        }
    }
}
