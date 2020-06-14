using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Contatos.Interfaces;
using Chat.Domain.Conversas.Dto;
using System.Collections.Generic;

namespace Chat.Application.Contatos
{
    public class ContatoStatusRepositorioApplication : IContatoStatusRepositorioApplication
    {
        private readonly IContatoStatusRepositorio _contatoStatusRepositorio;

        public ContatoStatusRepositorioApplication(
            IContatoStatusRepositorio contatoStatusRepositorio)
        {
            _contatoStatusRepositorio = contatoStatusRepositorio;
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
    }
}
