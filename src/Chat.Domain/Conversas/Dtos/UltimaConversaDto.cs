using Chat.Domain.Mensagens.Enums;
using System;

namespace Chat.Domain.Conversas.Dtos
{
    public class UltimaConversaDto
    {
        public int ConversaId { get; set; }
        public string UltimaMensagem { get; set; }
        public int UltimaMensagemId { get; set; }
        public StatusMensagem? StatusUltimaMensagem { get; set; }
        public int? ContatoRemetenteId { get; set; }
        public int? ContatoDestinatarioId { get; set; }
        public int ContatoAmigoId { get; set; }
        public DateTime? DataEnvio { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string FotoUrl { get; set; }
        public bool? Online { get; set; }
        public DateTime? DataRegistroOnline { get; set; }
        public bool? MostrarMensagensNovas { get; set; }
        public int? QtdMensagensNovas { get; set; }
        public bool? EhAmigo { get; set; }
    }
}
