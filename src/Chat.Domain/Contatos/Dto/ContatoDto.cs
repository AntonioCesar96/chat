using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.Contatos.Dto
{
    public class ContatoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string FotoUrl { get; set; }
    }
}
