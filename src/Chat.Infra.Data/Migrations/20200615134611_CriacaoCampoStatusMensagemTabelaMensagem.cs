using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Infra.Data.Migrations
{
    public partial class CriacaoCampoStatusMensagemTabelaMensagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusMensagem",
                table: "Mensagem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusMensagem",
                table: "Mensagem");
        }
    }
}
