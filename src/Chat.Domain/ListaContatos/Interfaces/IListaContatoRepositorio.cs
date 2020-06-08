using Chat.Domain.ListaContatos.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.ListaContatos.Interfaces
{
    public interface IListaContatoRepositorio
    {
        Task Salvar(ListaContato contato);
    }
}
