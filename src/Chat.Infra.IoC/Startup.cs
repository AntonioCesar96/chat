using Chat.Application.Contatos;
using Chat.Application.Contatos.Interfaces;
using Chat.Application.ListaContato;
using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.Contatos;
using Chat.Domain.Contatos.Interfaces;
using Chat.Domain.ListaContatos;
using Chat.Domain.ListaContatos.Interfaces;
using Chat.Infra.Data.Context;
using Chat.Infra.Data.Repositorios;
using Chat.Infra.Data.Consultas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chat.Domain.Conversas.Interfaces;
using Chat.Domain.Conversas;
using Chat.Application.Conversas.Interfaces;
using Chat.Application.Conversas;
using Chat.Domain.Common.Notifications;
using Chat.Domain.Common.Interfaces;
using Chat.Domain.ContatosStatus.Interfaces;
using Chat.Domain.Mensagens.Interfaces;
using Chat.Domain.ContatosStatus;
using Chat.Domain.Mensagens;
using Chat.Application.ContatosStatus.Interfaces;
using Chat.Application.Mensagens.Interfaces;
using Chat.Application.Mensagens;
using Chat.Application.ContatosStatus;
using AutoMapper;
using Chat.Infra.IoC.AutoMapper;

namespace Chat.Infra.IoC
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatDbContext>(options => 
                options.UseSqlServer(configuration["ConnectionStrings:Banco"]));
                        
            services.AddScoped<ChatDbContext, ChatDbContext>();            
            services.AddScoped(typeof(IDomainNotificationHandlerAsync<DomainNotification>), typeof(DomainNotificationHandlerAsync));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            // Application
            services.AddScoped(typeof(IArmazenadorDeContatoApplication), typeof(ArmazenadorDeContatoApplication));
            services.AddScoped(typeof(IConsultaConnectionsDeAmigosApplication), typeof(ConsultaConnectionsDeAmigosApplication));
            services.AddScoped(typeof(IArmazenadorContatoAmigoApplication), typeof(ArmazenadorContatoAmigoApplication));
            services.AddScoped(typeof(IArmazenadorDeMensagemApplication), typeof(ArmazenadorDeMensagemApplication));
            services.AddScoped(typeof(IConsultaListaContatoApplication), typeof(ConsultaListaContatoApplication));
            services.AddScoped(typeof(IConsultaMensagemApplication), typeof(ConsultaMensagemApplication));
            services.AddScoped(typeof(IConsultaConversaApplication), typeof(ConsultaConversaApplication));
            services.AddScoped(typeof(IAutenticacaoContatoApplication), typeof(AutenticacaoContatoApplication));
            services.AddScoped(typeof(IAtualizadorDeContatoStatusApplication), typeof(AtualizadorDeContatoStatusApplication));
            services.AddScoped(typeof(IRegistradorDeConexaoApplication), typeof(RegistradorDeConexaoApplication));
            services.AddScoped(typeof(IContatoStatusRepositorioApplication), typeof(ContatoStatusRepositorioApplication));
            services.AddScoped(typeof(IMarcadorDeMensagemLidaApplication), typeof(MarcadorDeMensagemLidaApplication));

            // Domain
            services.AddScoped(typeof(IArmazenadorDeContato), typeof(ArmazenadorDeContato));
            services.AddScoped(typeof(IArmazenadorDeContatoStatus), typeof(ArmazenadorDeContatoStatus));
            services.AddScoped(typeof(IArmazenadorContatoAmigo), typeof(ArmazenadorContatoAmigo));
            services.AddScoped(typeof(IArmazenadorDeConversa), typeof(ArmazenadorDeConversa));
            services.AddScoped(typeof(IArmazenadorDeMensagem), typeof(ArmazenadorDeMensagem));
            services.AddScoped(typeof(IAutenticacaoContato), typeof(AutenticacaoContato));
            services.AddScoped(typeof(IValidadorDeContato), typeof(ValidadorDeContato));
            services.AddScoped(typeof(IAtualizadorDeContatoStatus), typeof(AtualizadorDeContatoStatus));
            services.AddScoped(typeof(IRegistradorDeConexao), typeof(RegistradorDeConexao));
            services.AddScoped(typeof(IMarcadorDeMensagemLida), typeof(MarcadorDeMensagemLida));

            // Repository
            services.AddScoped(typeof(IConsultaListaContato), typeof(ConsultaListaContato));
            services.AddScoped(typeof(IConsultaConversa), typeof(ConsultaConversa));
            services.AddScoped(typeof(IConsultaMensagem), typeof(ConsultaMensagem));
            services.AddScoped(typeof(IConsultaConnectionsDeAmigos), typeof(ConsultaConnectionsDeAmigos));
            services.AddScoped(typeof(IContatoRepositorio), typeof(ContatoRepositorio));
            services.AddScoped(typeof(IContatoStatusRepositorio), typeof(ContatoStatusRepositorio));
            services.AddScoped(typeof(IListaContatoRepositorio), typeof(ListaContatoRepositorio));
            services.AddScoped(typeof(IConversaRepositorio), typeof(ConversaRepositorio));
            services.AddScoped(typeof(IMensagemRepositorio), typeof(MensagemRepositorio));

            services.AddAutoMapper();
        }
    }
}
