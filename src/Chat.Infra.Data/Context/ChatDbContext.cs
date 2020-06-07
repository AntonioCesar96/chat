using Chat.Infra.Data.Extensions;
using Chat.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Chat.Infra.Data.Context
{
    public class ChatDbContext : DbContext, IDesignTimeDbContextFactory<ChatDbContext>
    {
        public ChatDbContext() { }

        public ChatDbContext(DbContextOptions<ChatDbContext> options)
            : base(options) { }

        public ChatDbContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<ChatDbContext>();
            builder.UseSqlServer(config["ConnectionStrings:Banco"]);

            return new ChatDbContext(builder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new ContatoMapping());
            modelBuilder.AddConfiguration(new ConversaMapping());
            modelBuilder.AddConfiguration(new ListaContatoMapping());
        }
    }
}
