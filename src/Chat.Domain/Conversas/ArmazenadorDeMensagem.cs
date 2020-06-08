using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Entities;
using Chat.Domain.Conversas.Interfaces;
using System.Threading.Tasks;

namespace Chat.Domain.Conversas
{
    public class ArmazenadorDeMensagem : IArmazenadorDeMensagem
    {
        private readonly IConversaRepositorio _conversaRepositorio;
        private readonly IMensagemRepositorio _mensagemRepositorio;
        private readonly IArmazenadorDeConversa _armazenadorDeConversa;

        public ArmazenadorDeMensagem(
            IConversaRepositorio conversaRepositorio,
            IArmazenadorDeConversa armazenadorDeConversa,
            IMensagemRepositorio mensagemRepositorio)
        {
            _conversaRepositorio = conversaRepositorio;
            _armazenadorDeConversa = armazenadorDeConversa;
            _mensagemRepositorio = mensagemRepositorio;
        }

        public async Task<MensagemDto> Salvar(MensagemDto dto)
        {
            var conversa = _conversaRepositorio.ObterPorId(dto.ConversaId);
            if(conversa == null)
            {
                conversa = await _armazenadorDeConversa.Salvar(
                    dto.ContatoRemetenteId, dto.ContatoDestinatarioId);
            }

            var entity = new Mensagem(conversa.Id, dto.ContatoRemetenteId, 
                dto.ContatoDestinatarioId, dto.MensagemEnviada);

            await _mensagemRepositorio.Salvar(entity);

            dto.ConversaId = conversa.Id;
            dto.MensagemId = entity.Id;
            dto.DataEnvio = entity.DataEnvio;
            return dto;
        }
    }
}
