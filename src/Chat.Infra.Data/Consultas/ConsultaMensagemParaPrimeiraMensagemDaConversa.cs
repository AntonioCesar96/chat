using AutoMapper;
using Chat.Domain.ListaContatos.Entidades;
using Chat.Domain.Mensagens.Dtos;
using Chat.Domain.Mensagens.Entidades;
using Chat.Domain.Mensagens.Interfaces;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Infra.Data.Consultas
{
    public class ConsultaMensagemParaPrimeiraMensagemDaConversa : IConsultaMensagemParaPrimeiraMensagemDaConversa
    {
        private readonly ChatDbContext _dbContext;
        private readonly IMapper _mapper;

        public ConsultaMensagemParaPrimeiraMensagemDaConversa(
            ChatDbContext dbContext, 
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MensagemContatosDto ObterMensagem(int mensagemId)
        {
            var mensagemDto = ObterMensagemDto(mensagemId);
            var listaContatos = ObterListaContatosSeForemAmigos(mensagemDto);

            PreencherDadosDestinatario(mensagemDto, listaContatos);
            PreencherDadosRemetente(mensagemDto, listaContatos);

            return mensagemDto;
        }

        private void PreencherDadosDestinatario(MensagemContatosDto mensagemDto, List<ListaContato> listaContatos)
        {
            var remetenteEhAmigoDoDestinatario = listaContatos.Any(x =>
                x.ContatoPrincipalId == mensagemDto.ContatoRemetenteId &&
                x.ContatoAmigoId == mensagemDto.ContatoDestinatarioId);

            if (remetenteEhAmigoDoDestinatario) return;

            mensagemDto.NomeDestinatario = mensagemDto.EmailDestinatario;
            mensagemDto.DescricaoDestinatario = null;
            mensagemDto.FotoUrlDestinatario = null;
        }

        private void PreencherDadosRemetente(MensagemContatosDto mensagemDto, List<ListaContato> listaContatos)
        {
            var destinatarioEhAmigoDoRemetente = listaContatos.Any(x =>
                x.ContatoPrincipalId == mensagemDto.ContatoDestinatarioId &&
                x.ContatoAmigoId == mensagemDto.ContatoRemetenteId);

            if (destinatarioEhAmigoDoRemetente) return;

            mensagemDto.NomeRemetente = mensagemDto.EmailRemetente;
            mensagemDto.DescricaoRemetente = null;
            mensagemDto.FotoUrlRemetente = null;
        }

        private List<ListaContato> ObterListaContatosSeForemAmigos(MensagemContatosDto mensagemDto)
        {
            return _dbContext.Set<ListaContato>()
                    .Where(lista => (
                            lista.ContatoPrincipalId == mensagemDto.ContatoRemetenteId &&
                            lista.ContatoAmigoId == mensagemDto.ContatoDestinatarioId
                        ) ||
                        (
                            lista.ContatoPrincipalId == mensagemDto.ContatoDestinatarioId &&
                            lista.ContatoAmigoId == mensagemDto.ContatoRemetenteId
                        )
                    ).ToList();
        }

        private MensagemContatosDto ObterMensagemDto(int mensagemId)
        {
            var mensagem = _dbContext.Set<Mensagem>()
                .Include(x => x.ContatoDestinatario)
                .Include(x => x.ContatoRemetente)
                .FirstOrDefault(x => x.Id == mensagemId);

            return _mapper.Map<MensagemContatosDto>(mensagem);
        }
    }
}
