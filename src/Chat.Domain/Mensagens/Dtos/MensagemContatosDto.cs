using Chat.Domain.Mensagens.Enums;
using System;

namespace Chat.Domain.Mensagens.Dtos
{
    public class MensagemContatosDto : MensagemDto
    {
        public string EmailRemetente { get; set; }
        public string NomeRemetente { get; set; }
        public string DescricaoRemetente { get; set; }
        public string FotoUrlRemetente { get; set; }


        public string EmailDestinatario { get; set; }
        public string NomeDestinatario { get; set; }
        public string DescricaoDestinatario { get; set; }
        public string FotoUrlDestinatario { get; set; }
    }
}
