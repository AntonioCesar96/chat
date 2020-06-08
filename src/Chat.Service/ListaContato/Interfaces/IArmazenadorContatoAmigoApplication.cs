using Chat.Domain.Common;
using Chat.Domain.ListaContatos.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.ListaContato.Interfaces
{
    public interface IArmazenadorContatoAmigoApplication
    {
        Task<int> Salvar(ContatoAmigoCriacaoDto dto);
    }
}
