using Chat.Application.Contatos;
using Chat.Application.Contatos.Interfaces;
using Chat.Application.ListaContato;
using Chat.Application.ListaContato.Interfaces;
using Chat.Domain.Contatos;
using Chat.Domain.Contatos.Interfaces;
using Chat.Domain.ListaContatos.Interfaces;
using Chat.Infra.Data.Context;
using Chat.Infra.Data.Repository.Contatos;
using Chat.Infra.Data.Repository.ListaContatos;
using Chat.Infra.Util.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            services.AddScoped(typeof(IConsultaListaContatoApplication), typeof(ConsultaListaContatoApplication));

            // Domain
            services.AddScoped(typeof(IArmazenadorDeContato), typeof(ArmazenadorDeContato));
            services.AddScoped(typeof(IConsultaListaContato), typeof(ConsultaListaContato));
            services.AddScoped(typeof(IContatoRepositorio), typeof(ContatoRepositorio));

            AutoMapperConfiguration.Initialize();
        }
    }
}
