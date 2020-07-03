using Chat.Application.Contatos.Interfaces;
using Chat.Domain.Contatos.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Application.Contatos
{
    public class RegistradorDeConexaoApplication : IRegistradorDeConexaoApplication
    {
        private readonly IRegistradorDeConexao _registradorDeConexao;

        public RegistradorDeConexaoApplication(
            IRegistradorDeConexao registradorDeConexao)
        {
            _registradorDeConexao = registradorDeConexao;
        }

        public async Task<List<string>> Registrar(int contatoId, string connectionId)
        {
            var connectionsIds = await _registradorDeConexao.Registrar(contatoId, connectionId);
            return connectionsIds;
        }
    }
}
