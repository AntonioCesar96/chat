using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Infra.Data.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: true),
                    FotoUrl = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conversa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContatoCriadorDaConversaId = table.Column<int>(nullable: false),
                    ContatoId = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversa_Contato_ContatoCriadorDaConversaId",
                        column: x => x.ContatoCriadorDaConversaId,
                        principalTable: "Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversa_Contato_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListaContato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContatoPrincipalId = table.Column<int>(nullable: false),
                    ContatoAmigoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaContato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaContato_Contato_ContatoAmigoId",
                        column: x => x.ContatoAmigoId,
                        principalTable: "Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListaContato_Contato_ContatoPrincipalId",
                        column: x => x.ContatoPrincipalId,
                        principalTable: "Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConversaId = table.Column<int>(nullable: false),
                    ContatoRemetenteId = table.Column<int>(nullable: false),
                    ContatoDestinatarioId = table.Column<int>(nullable: false),
                    MensagemEnviada = table.Column<string>(nullable: false),
                    DataEnvio = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagem_Contato_ContatoDestinatarioId",
                        column: x => x.ContatoDestinatarioId,
                        principalTable: "Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensagem_Contato_ContatoRemetenteId",
                        column: x => x.ContatoRemetenteId,
                        principalTable: "Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensagem_Conversa_ConversaId",
                        column: x => x.ConversaId,
                        principalTable: "Conversa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversa_ContatoCriadorDaConversaId",
                table: "Conversa",
                column: "ContatoCriadorDaConversaId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversa_ContatoId",
                table: "Conversa",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaContato_ContatoAmigoId",
                table: "ListaContato",
                column: "ContatoAmigoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaContato_ContatoPrincipalId",
                table: "ListaContato",
                column: "ContatoPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ContatoDestinatarioId",
                table: "Mensagem",
                column: "ContatoDestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ContatoRemetenteId",
                table: "Mensagem",
                column: "ContatoRemetenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ConversaId",
                table: "Mensagem",
                column: "ConversaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaContato");

            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "Conversa");

            migrationBuilder.DropTable(
                name: "Contato");
        }
    }
}
