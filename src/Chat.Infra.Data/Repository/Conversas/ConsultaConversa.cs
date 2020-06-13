using Chat.Domain.Common;
using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Entities;
using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Entities;
using Chat.Domain.Conversas.Interfaces;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var pagina = filtro.Pagina > 0 ? filtro.Pagina : 1;
            var calculoPaginacao = (pagina - 1) * filtro.TotalPorPagina;

            IQueryable<UltimaConversaDto> conversas = CriarConsultaDeConversas(filtro);

            var total = conversas.Count();
            var lista = conversas.Skip(calculoPaginacao).Take(filtro.TotalPorPagina).ToList();

            var mensagensIds = lista.Select(x => x.UltimaMensagemId).ToList();
            var ultimasMensagens = ObterMensagens(mensagensIds);

            var contatosAmigosIds = lista.Select(x => x.ContatoAmigoId).ToList();
            var statusDosContatos = ObterStatusDosContatos(contatosAmigosIds);

            AtualizarLista(lista, ultimasMensagens, statusDosContatos);

            var retorno = new ResultadoDaConsulta();
            retorno.Pagina = pagina;
            retorno.TotalPorPagina = filtro.TotalPorPagina;
            retorno.Total = total;
            retorno.Lista = lista;

            return retorno;
        }

        private static void AtualizarLista(List<UltimaConversaDto> lista, 
            List<UltimaConversaDto> ultimasMensagens, List<ContatoMensagemDto> statusDosContatos)
        {
            lista.ForEach(ultimaMensagem =>
            {
                var status = statusDosContatos.FirstOrDefault(y => y.ContatoId == ultimaMensagem.ContatoAmigoId);
                var mensagem = ultimasMensagens.FirstOrDefault(y => y.UltimaMensagemId == ultimaMensagem.UltimaMensagemId);

                ultimaMensagem.Nome = status?.Nome;
                ultimaMensagem.Email = status?.Email;
                ultimaMensagem.FotoUrl = status?.FotoUrl;
                ultimaMensagem.Online = status?.Online;
                ultimaMensagem.DataRegistroOnline = status?.DataRegistroOnline;
                ultimaMensagem.UltimaMensagem = mensagem?.UltimaMensagem;
                ultimaMensagem.ContatoRemetenteId = mensagem?.ContatoRemetenteId;
                ultimaMensagem.ContatoDestinatarioId = mensagem?.ContatoDestinatarioId;
                ultimaMensagem.DataEnvio = mensagem?.DataEnvio;
            });
        }

        private IQueryable<UltimaConversaDto> CriarConsultaDeConversas(ConversaFiltroDto filtro)
        {
            return (
                from conversa in _dbContext.Set<Conversa>()
                join mensagem in _dbContext.Set<Mensagem>()
                    on conversa.Id equals mensagem.ConversaId

                group mensagem by new
                {
                    ConversaId = conversa.Id,
                    conversa.ContatoCriadorDaConversaId,
                    conversa.ContatoId
                } into conversaGroup

                where conversaGroup.Key.ContatoCriadorDaConversaId == filtro.ContatoId
                    || conversaGroup.Key.ContatoId == filtro.ContatoId

                select new UltimaConversaDto()
                {
                    UltimaMensagemId = conversaGroup.Max(x => x.Id),
                    ConversaId = conversaGroup.Key.ConversaId,
                    ContatoAmigoId = conversaGroup.Key.ContatoId == filtro.ContatoId 
                        ? conversaGroup.Key.ContatoCriadorDaConversaId : conversaGroup.Key.ContatoId
                }
            );
        }

        private List<ContatoMensagemDto> ObterStatusDosContatos(List<int> contatosAmigosIds)
        {
            return (
                from contato in _dbContext.Set<Contato>()

                join statusLeft in _dbContext.Set<ContatoStatus>()
                    on contato.Id equals statusLeft.ContatoId into statusLeft
                from status in statusLeft.DefaultIfEmpty()

                where contatosAmigosIds.Any(id => id == contato.Id)

                select new ContatoMensagemDto()
                {
                    ContatoId = contato.Id,
                    Nome = contato.Nome,
                    Email = contato.Email,
                    FotoUrl = contato.FotoUrl,
                    Online = status != null ? (bool?)status.Online : null,
                    DataRegistroOnline = status != null ? (DateTime?)status.Data : null,
                }
            ).ToList();
        }

        private List<UltimaConversaDto> ObterMensagens(List<int> mensagensIds)
        {
            return (
                from mensagem in _dbContext.Set<Mensagem>()

                where mensagensIds.Any(id => id == mensagem.Id)

                select new UltimaConversaDto()
                {
                    UltimaMensagemId = mensagem.Id,
                    UltimaMensagem = mensagem.MensagemEnviada,
                    ContatoRemetenteId = mensagem.ContatoRemetenteId,
                    ContatoDestinatarioId = mensagem.ContatoDestinatarioId,
                    DataEnvio = mensagem.DataEnvio,
                }
            ).ToList();
        }
    }
}
