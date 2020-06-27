using Chat.Api.Hubs;
using Chat.Api.Jwt;
using Chat.Infra.Data.Context;
using Chat.Infra.IoC.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.IO;

namespace Chat.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:4263")
                        .AllowCredentials());
            });

            services.AddOptions();
            services.AddSingleton(provider => Configuration);

            Infra.IoC.Startup.ConfigureServices(services, Configuration);

            services.AddScoped<MensagemHub>();
            services.AddScoped<ConexaoHub>();
            services.AddScoped<ConversasHub>();
            services.AddScoped<ContatoHub>();
            services.AddScoped<TokenService>();

            services.AddControllers();
            services.AddSignalR(o => { o.EnableDetailedErrors = true; });
            services.AddJwt(Configuration["JwtSettings:SigningKey"]);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            /*
            app.Use(async (context, next) =>
            {
                var url = context.Request.Path.Value;
                if (url.Contains("api") || url.Contains("chatHub"))
                {
                    await next();
                    return;
                }
                context.Response.Redirect("/index.html");
            });
            */

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chatHub");
            });

            Infra.Data.Startup.RunMigration<ChatDbContext>(app);
        }
    }
}
