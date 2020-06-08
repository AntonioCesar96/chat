using Chat.Application.Contatos;
using Chat.Application.Contatos.Interfaces;
using Chat.Application.ListaContato;
using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.Contatos;
using Chat.Domain.Contatos.Interfaces;
using Chat.Domain.ListaContatos;
using Chat.Domain.ListaContatos.Interfaces;
using Chat.Infra.Data.Context;
using Chat.Infra.Data.Repository.Contatos;
using Chat.Infra.Data.Repository.ListaContatos;
using Chat.Infra.Data.Repository.Conversas;
using Chat.Infra.Util.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Chat.Domain.Conversas.Interfaces;
using Chat.Domain.Conversas;
using Chat.Application.Conversas.Interfaces;
using Chat.Application.Conversas;

namespace Chat.Infra.IoC
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatDbContext>(options => 
                options.UseSqlServer(configuration["ConnectionStrings:Banco"]));

            // Application
            services.AddScoped(typeof(IArmazenadorDeContatoApplication), typeof(ArmazenadorDeContatoApplication));
            services.AddScoped(typeof(IArmazenadorContatoAmigoApplication), typeof(ArmazenadorContatoAmigoApplication));
            services.AddScoped(typeof(IArmazenadorDeMensagemApplication), typeof(ArmazenadorDeMensagemApplication));
            services.AddScoped(typeof(IConsultaListaContatoApplication), typeof(ConsultaListaContatoApplication));
            services.AddScoped(typeof(IConsultaMensagemApplication), typeof(ConsultaMensagemApplication));
            services.AddScoped(typeof(IConsultaConversaApplication), typeof(ConsultaConversaApplication));

            // Domain
            services.AddScoped(typeof(IArmazenadorDeContato), typeof(ArmazenadorDeContato));
            services.AddScoped(typeof(IArmazenadorContatoAmigo), typeof(ArmazenadorContatoAmigo));
            services.AddScoped(typeof(IArmazenadorDeConversa), typeof(ArmazenadorDeConversa));
            services.AddScoped(typeof(IArmazenadorDeMensagem), typeof(ArmazenadorDeMensagem));

            // Repository
            services.AddScoped(typeof(IConsultaListaContato), typeof(ConsultaListaContato));
            services.AddScoped(typeof(IConsultaConversa), typeof(ConsultaConversa));
            services.AddScoped(typeof(IConsultaMensagem), typeof(ConsultaMensagem));
            services.AddScoped(typeof(IContatoRepositorio), typeof(ContatoRepositorio));
            services.AddScoped(typeof(IListaContatoRepositorio), typeof(ListaContatoRepositorio));
            services.AddScoped(typeof(IConversaRepositorio), typeof(ConversaRepositorio));
            services.AddScoped(typeof(IMensagemRepositorio), typeof(MensagemRepositorio));

            AutoMapperConfiguration.Initialize();
        }
    }
}
