using AutoMapper;
using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Entities;
using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Entities;
using Chat.Domain.ListaContatos.Dto;
using Chat.Domain.ListaContatos.Entities;

namespace Chat.Infra.Util.AutoMapper
{
    public class ChatMappingProfile : Profile
    {
        public ChatMappingProfile()
        {
            CreateMap<Contato, ContatoDto>();
            CreateMap<Conversa, ConversaDto>();
            CreateMap<ListaContato, ListaContatoDto>();
        }
    }
}
