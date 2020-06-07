using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Entities;
using Chat.Infra.Data.Context;
using Chat.Service.Interfaces;
using System.Threading.Tasks;
using Chat.Infra.Util.AutoMapper;
using Chat.Domain.ListaContatos.Dto;
using Chat.Domain.Common;
using Chat.Domain.ListaContatos.Entities;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;

namespace Chat.Service.Chat
{
    public class ContatoService : IContatoService
    {
        private readonly ChatDbContext _dbContext;

        public ContatoService(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Salvar(ContatoDto dto)
        {
            var entity = dto.MapTo<Contato>();

            _dbContext.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public ResultadoDaConsulta ObterListaDeContatos(ListaContatoFiltroDto filtro)
        {
            try
            {
                var retorno = new ResultadoDaConsulta();

                var pagina = filtro.Pagina > 0 ? filtro.Pagina : 1;
                var calculoPaginacao = (pagina - 1) * filtro.TotalPorPagina;

                var postagens = _dbContext.Set<ListaContato>().Select(p => p);

                retorno.Pagina = pagina;
                retorno.TotalPorPagina = filtro.TotalPorPagina;
                retorno.Total = postagens.Count();
                retorno.Lista = Mapper.Map<List<ListaContatoDto>>(postagens
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
