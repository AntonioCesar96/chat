using AutoMapper;
using Chat.Application.ContatosStatus.Interfaces;
using Chat.Domain.ContatosStatus.Dtos;
using Chat.Domain.ContatosStatus.Interfaces;
using Chat.Domain.Mensagens.Dtos;
using System.Collections.Generic;

namespace Chat.Application.ContatosStatus
{
    public class ContatoStatusRepositorioApplication : IContatoStatusRepositorioApplication
    {
        private readonly IContatoStatusRepositorio _contatoStatusRepositorio;
        private readonly IMapper _mapper;

        public ContatoStatusRepositorioApplication(
            IContatoStatusRepositorio contatoStatusRepositorio,
            IMapper mapper)
        {
            _contatoStatusRepositorio = contatoStatusRepositorio;
            _mapper = mapper;
        }

        public List<string> ObterConnectionsIdsPorContatosIds(int contatoId)
        {
            return _contatoStatusRepositorio.ObterConnectionsIdsPorContatosIds(new List<int>() { contatoId });
        }

        public List<string> ObterConnectionsIdsPorContatosIds(MensagemDto dto)
        {
            var contatosIds = new List<int>() { dto.ContatoRemetenteId, dto.ContatoDestinatarioId };
            return _contatoStatusRepositorio.ObterConnectionsIdsPorContatosIds(contatosIds);
        }

        public ContatoStatusDto ObterPorContato(int contatoId)
        {
            var contatoStatus = _contatoStatusRepositorio.ObterPorContato(contatoId);
            return _mapper.Map<ContatoStatusDto>(contatoStatus);
        }
    }
}
