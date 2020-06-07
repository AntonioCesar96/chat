using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.ListaContatos.Dto
{
    public class ListaContatoDto
    {
        public int Id { get; private set; }
        public int ContatoPrincipalId { get; private set; }
        public int ContatoAmigoId { get; private set; }
    }
}
