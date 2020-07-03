using AutoMapper;
using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Contatos.Dtos;
using Chat.Domain.Contatos.Interfaces;

namespace Chat.Application.Contatos
{
    public class ContatoRepositorioApplication : IContatoRepositorioApplication
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly IMapper _mapper;

        public ContatoRepositorioApplication(
            IContatoRepositorio contatoRepositorio,
            IMapper mapper)
        {
            _contatoRepositorio = contatoRepositorio;
            _mapper = mapper;
        }

        public ContatoDto ObterPorEmail(string email)
        {
            var contato = _contatoRepositorio.ObterPorEmail(email);
            return _mapper.Map<ContatoDto>(contato);
        }
    }
}
