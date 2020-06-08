using AutoMapper;
using Chat.Domain.Contatos.Dto;
using Chat.Domain.Contatos.Entities;
using Chat.Domain.Conversas.Dto;
using Chat.Domain.Conversas.Entities;
using Chat.Domain.ListaContatos.Dto;
using Chat.Domain.ListaContatos.Entities;
using System.Linq;

namespace Chat.Infra.Util.AutoMapper
{
    public class ChatMappingProfile : Profile
    {
        public ChatMappingProfile()
        {
            CreateMap<Contato, ContatoDto>()
                .ForMember(r => r.ContatoId, o => o.MapFrom(c => c.Id));

            CreateMap<Conversa, ConversaDto>()
                .ForMember(r => r.ConversaId, o => o.MapFrom(c => c.Id));

            CreateMap<Mensagem, MensagemDto>()
                .ForMember(r => r.MensagemId, o => o.MapFrom(c => c.Id));

            CreateMap<ListaContato, ListaAmigosDto>()
                .ForMember(r => r.ListaContatoId, o => o.MapFrom(c => c.Id))
                .ForMember(r => r.ContatoPrincipalId, o => o.MapFrom(c => c.ContatoPrincipalId))
                .ForMember(r => r.NomeAmigo, o => o.MapFrom(c => c.ContatoAmigo.Nome))
                .ForMember(r => r.EmailAmigo, o => o.MapFrom(c => c.ContatoAmigo.Email))
                .ForMember(r => r.ContatoAmigoId, o => o.MapFrom(c => c.ContatoAmigoId));
        }
    }
}
