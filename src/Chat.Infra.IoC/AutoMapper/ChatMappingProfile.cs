using AutoMapper;
using Chat.Domain.Contatos.Dtos;
using Chat.Domain.Contatos.Entidades;
using Chat.Domain.ContatosStatus.Dtos;
using Chat.Domain.ContatosStatus.Entidades;
using Chat.Domain.Conversas.Dtos;
using Chat.Domain.Conversas.Entidades;
using Chat.Domain.ListaContatos.Dtos;
using Chat.Domain.ListaContatos.Entidades;
using Chat.Domain.Mensagens.Dtos;
using Chat.Domain.Mensagens.Entidades;

namespace Chat.Infra.IoC.AutoMapper
{
    public class ChatMappingProfile : Profile
    {
        public ChatMappingProfile()
        {
            CreateMap<Contato, ContatoDto>()
                .ForMember(r => r.ContatoId, o => o.MapFrom(c => c.Id));

            CreateMap<ContatoStatus, ContatoStatusDto>();

            CreateMap<Conversa, UltimaConversaDto>()
                .ForMember(r => r.ConversaId, o => o.MapFrom(c => c.Id));

            CreateMap<Mensagem, MensagemDto>()
                .ForMember(r => r.MensagemId, o => o.MapFrom(c => c.Id));

            CreateMap<Mensagem, MensagemContatosDto>()
                .ForMember(r => r.MensagemId, o => o.MapFrom(c => c.Id))
                .ForMember(r => r.NomeRemetente, o => o.MapFrom(c => c.ContatoRemetente.Nome))
                .ForMember(r => r.EmailRemetente, o => o.MapFrom(c => c.ContatoRemetente.Email))
                .ForMember(r => r.DescricaoRemetente, o => o.MapFrom(c => c.ContatoRemetente.Descricao))
                .ForMember(r => r.FotoUrlRemetente, o => o.MapFrom(c => c.ContatoRemetente.FotoUrl))
                .ForMember(r => r.NomeDestinatario, o => o.MapFrom(c => c.ContatoDestinatario.Nome))
                .ForMember(r => r.EmailDestinatario, o => o.MapFrom(c => c.ContatoDestinatario.Email))
                .ForMember(r => r.DescricaoDestinatario, o => o.MapFrom(c => c.ContatoDestinatario.Descricao))
                .ForMember(r => r.FotoUrlDestinatario, o => o.MapFrom(c => c.ContatoDestinatario.FotoUrl));

            CreateMap<ListaContato, ListaAmigosDto>()
                .ForMember(r => r.ListaContatoId, o => o.MapFrom(c => c.Id))
                .ForMember(r => r.ContatoPrincipalId, o => o.MapFrom(c => c.ContatoPrincipalId))
                .ForMember(r => r.NomeAmigo, o => o.MapFrom(c => c.ContatoAmigo.Nome))
                .ForMember(r => r.EmailAmigo, o => o.MapFrom(c => c.ContatoAmigo.Email))
                .ForMember(r => r.FotoUrl, o => o.MapFrom(c => c.ContatoAmigo.FotoUrl))
                .ForMember(r => r.ContatoAmigoId, o => o.MapFrom(c => c.ContatoAmigoId));
        }
    }
}
