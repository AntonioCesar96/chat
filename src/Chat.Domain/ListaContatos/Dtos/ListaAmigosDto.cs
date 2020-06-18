namespace Chat.Domain.ListaContatos.Dtos
{
    public class ListaAmigosDto
    {
        public int ListaContatoId { get; set; }
        public int ContatoPrincipalId { get; set; }
        public string NomeAmigo { get; set; }
        public string EmailAmigo { get; set; }
        public string FotoUrl { get; set; }
        public int ContatoAmigoId { get; set; }
    }
}
