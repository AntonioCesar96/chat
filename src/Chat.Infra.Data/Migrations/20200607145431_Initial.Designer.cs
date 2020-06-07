﻿// <auto-generated />
using System;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chat.Infra.Data.Migrations
{
    [DbContext(typeof(ChatDbContext))]
    [Migration("20200607145431_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Chat.Domain.Contatos.Entities.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FotoUrl")
                        .HasMaxLength(250);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("Chat.Domain.Conversas.Entities.Conversa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContatoDoisId");

                    b.Property<int>("ContatoUmId");

                    b.Property<DateTime>("DataEnvio");

                    b.Property<string>("Mensagem")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ContatoDoisId");

                    b.HasIndex("ContatoUmId");

                    b.ToTable("Conversa");
                });

            modelBuilder.Entity("Chat.Domain.ListaContatos.Entities.ListaContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContatoAmigoId");

                    b.Property<int>("ContatoPrincipalId");

                    b.HasKey("Id");

                    b.HasIndex("ContatoAmigoId");

                    b.HasIndex("ContatoPrincipalId");

                    b.ToTable("ListaContato");
                });

            modelBuilder.Entity("Chat.Domain.Conversas.Entities.Conversa", b =>
                {
                    b.HasOne("Chat.Domain.Contatos.Entities.Contato", "ContatoDois")
                        .WithMany()
                        .HasForeignKey("ContatoDoisId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Chat.Domain.Contatos.Entities.Contato", "ContatoUm")
                        .WithMany()
                        .HasForeignKey("ContatoUmId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Chat.Domain.ListaContatos.Entities.ListaContato", b =>
                {
                    b.HasOne("Chat.Domain.Contatos.Entities.Contato", "ContatoAmigo")
                        .WithMany()
                        .HasForeignKey("ContatoAmigoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Chat.Domain.Contatos.Entities.Contato", "ContatoPrincipal")
                        .WithMany()
                        .HasForeignKey("ContatoPrincipalId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
