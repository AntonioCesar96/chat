using Chat.Domain.Common;
using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Entities;
using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Entities;
using Chat.Domain.Conversas.Enums;
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
            var conversas = Obterconversas(filtro);
            PreencherConversas(filtro, conversas);

            var retorno = new ResultadoDaConsulta();
            retorno.Total = conversas.Count();
            retorno.Lista = conversas
                .OrderByDescending(x => x.DataEnvio)
                .ToList();

            return retorno;
        }

        private void PreencherConversas(ConversaFiltroDto filtro,
            List<UltimaConversaDto> conversas)
        {
            var mensagensIds = conversas.Select(x => x.UltimaMensagemId).ToList();
            var ultimasMensagens = ObterMensagens(mensagensIds);

            var conversasIds = conversas.Select(x => x.ConversaId).ToList();
            var qtdMensagensNovasPorConversa = ObterQtdMensagensNovasPorConversa(conversasIds);

            var contatosAmigosIds = conversas.Select(x => x.ContatoAmigoId).ToList();
            var statusDosContatos = ObterStatusDosContatos(contatosAmigosIds);

            conversas.ForEach(ultimaMensagem =>
            {
                var quantidades = qtdMensagensNovasPorConversa.FirstOrDefault(y => y.ConversaId == ultimaMensagem.ConversaId);
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
                ultimaMensagem.StatusUltimaMensagem = mensagem?.StatusUltimaMensagem;
                ultimaMensagem.QtdMensagensNovas = quantidades?.QtdMensagensNovas ?? 0;
                ultimaMensagem.MostrarMensagensNovas = 
                    mensagem?.ContatoDestinatarioId == filtro.ContatoId && ultimaMensagem.QtdMensagensNovas > 0;
            });
        }

        private List<UltimaConversaDto> Obterconversas(ConversaFiltroDto filtro)
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
            ).ToList();
        }

        private List<UltimaConversaDto> ObterQtdMensagensNovasPorConversa(List<int> conversasIds)
        {
            return (
                from mensagem in _dbContext.Set<Mensagem>()

                group mensagem by new { mensagem.ConversaId, mensagem.StatusMensagem } into mensagemGroup

                where mensagemGroup.Key.StatusMensagem != StatusMensagem.Lida
                && conversasIds.Any(id => id == mensagemGroup.Key.ConversaId)

                select new UltimaConversaDto()
                {
                    QtdMensagensNovas = mensagemGroup.Count(),
                    ConversaId = mensagemGroup.Key.ConversaId,
                }
            ).ToList();
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
                    StatusUltimaMensagem = mensagem.StatusMensagem,
                }
            ).ToList();
        }
    }
}
