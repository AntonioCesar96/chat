using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Infra.Data.Migrations
{
    public partial class RemocaoLimiteCampoFotoUrlTabelaContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FotoUrl",
                table: "Contato",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FotoUrl",
                table: "Contato",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
