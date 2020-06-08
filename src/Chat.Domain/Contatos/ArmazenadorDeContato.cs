using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Entities;
using Chat.Domain.Contatos.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Contatos
{
    public class ArmazenadorDeContato : IArmazenadorDeContato
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ArmazenadorDeContato(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public async Task<int> Salvar(ContatoDto dto)
        {
            var entity = new Contato(dto.Nome, dto.Email);

            await _contatoRepositorio.Salvar(entity);

            return entity.Id;
        }
    }
}
