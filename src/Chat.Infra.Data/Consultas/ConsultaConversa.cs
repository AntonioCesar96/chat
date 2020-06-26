using Chat.Domain.Common;
using Chat.Domain.Contatos.Dtos;
using Chat.Domain.Contatos.Entidades;
using Chat.Domain.ContatosStatus.Entidades;
using Chat.Domain.Conversas.Dtos;
using Chat.Domain.Conversas.Entidades;
using Chat.Domain.Conversas.Interfaces;
using Chat.Domain.ListaContatos.Entidades;
using Chat.Domain.Mensagens.Entidades;
using Chat.Domain.Mensagens.Enums;
using Chat.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Infra.Data.Consultas
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
            var conversas = ObterConversas(filtro);
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

            var listaContatos = ObterListaContatosSeForemAmigos(filtro.ContatoId, contatosAmigosIds);

            conversas.ForEach(ultimaMensagem =>
            {
                var quantidades = qtdMensagensNovasPorConversa.FirstOrDefault(y => y.ConversaId == ultimaMensagem.ConversaId);
                var status = statusDosContatos.FirstOrDefault(y => y.ContatoId == ultimaMensagem.ContatoAmigoId);
                var mensagem = ultimasMensagens.FirstOrDefault(y => y.UltimaMensagemId == ultimaMensagem.UltimaMensagemId);
                var amigo = listaContatos.FirstOrDefault(y => y.ContatoAmigoId == ultimaMensagem.ContatoAmigoId);

                ultimaMensagem.Nome = status?.Nome;
                ultimaMensagem.Email = status?.Email;
                ultimaMensagem.FotoUrl = status?.FotoUrl;
                ultimaMensagem.EhAmigo = true;
                ultimaMensagem.UltimaMensagem = mensagem?.UltimaMensagem;
                ultimaMensagem.ContatoRemetenteId = mensagem?.ContatoRemetenteId;
                ultimaMensagem.ContatoDestinatarioId = mensagem?.ContatoDestinatarioId;
                ultimaMensagem.DataEnvio = mensagem?.DataEnvio;
                ultimaMensagem.StatusUltimaMensagem = mensagem?.StatusUltimaMensagem;
                ultimaMensagem.QtdMensagensNovas = quantidades?.QtdMensagensNovas ?? 0;
                ultimaMensagem.MostrarMensagensNovas = 
                    mensagem?.ContatoDestinatarioId == filtro.ContatoId && ultimaMensagem.QtdMensagensNovas > 0;

                if (amigo != null) return;

                ultimaMensagem.EhAmigo = false;
                ultimaMensagem.Nome = ultimaMensagem.Email;
                ultimaMensagem.FotoUrl = null;
            });
        }

        private List<UltimaConversaDto> ObterConversas(ConversaFiltroDto filtro)
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

                where contatosAmigosIds.Any(id => id == contato.Id)

                select new ContatoMensagemDto()
                {
                    ContatoId = contato.Id,
                    Nome = contato.Nome,
                    Email = contato.Email,
                    FotoUrl = contato.FotoUrl
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

        private List<ListaContato> ObterListaContatosSeForemAmigos(int contatoId, List<int> contatosAmigosIds)
        {
            return _dbContext.Set<ListaContato>()
                    .Where(lista => lista.ContatoPrincipalId == contatoId 
                        && contatosAmigosIds.Any(id => id == lista.ContatoAmigoId)
                    ).ToList();
        }
    }
}
