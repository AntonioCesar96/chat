using Chat.Domain.Contatos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Application.Contatos.Interfaces
{
    public interface IContatoRepositorioApplication
    {
        ContatoDto ObterPorEmail(string email);
    }
}
