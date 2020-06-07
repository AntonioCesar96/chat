using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
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
                    ContatoUmId = table.Column<int>(nullable: false),
                    ContatoDoisId = table.Column<int>(nullable: false),
                    Mensagem = table.Column<string>(nullable: false),
                    DataEnvio = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversa_Contato_ContatoDoisId",
                        column: x => x.ContatoDoisId,
                        principalTable: "Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversa_Contato_ContatoUmId",
                        column: x => x.ContatoUmId,
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

            migrationBuilder.CreateIndex(
                name: "IX_Conversa_ContatoDoisId",
                table: "Conversa",
                column: "ContatoDoisId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversa_ContatoUmId",
                table: "Conversa",
                column: "ContatoUmId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaContato_ContatoAmigoId",
                table: "ListaContato",
                column: "ContatoAmigoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaContato_ContatoPrincipalId",
                table: "ListaContato",
                column: "ContatoPrincipalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversa");

            migrationBuilder.DropTable(
                name: "ListaContato");

            migrationBuilder.DropTable(
                name: "Contato");
        }
    }
}
