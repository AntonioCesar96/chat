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
            CreateMap<ListaContato, ListaAmigosDto>()
                .ForMember(r => r.ListaContatoId, o => o.MapFrom(c => c.Id))
                .ForMember(r => r.ContatoPrincipalId, o => o.MapFrom(c => c.ContatoPrincipalId))
                .ForMember(r => r.NomeAmigo, o => o.MapFrom(c => c.ContatoAmigo.Nome))
                .ForMember(r => r.EmailAmigo, o => o.MapFrom(c => c.ContatoAmigo.Email))
                .ForMember(r => r.ContatoAmigoId, o => o.MapFrom(c => c.ContatoAmigoId));
        }
    }
}
