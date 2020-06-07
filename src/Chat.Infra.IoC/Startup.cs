using Chat.Infra.Data.Context;
using Chat.Infra.Util.AutoMapper;
using Chat.Service.Chat;
using Chat.Service.Interfaces;
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

             services.AddScoped(typeof(IContatoService), typeof(ContatoService));
            // services.AddScoped<PostagemService>();

            AutoMapperConfiguration.Initialize();
        }
    }
}
