namespace Chat.Domain.ListaContatos.Dtos
{
    public class ListaAmigosDto
    {
        public int ListaContatoId { get; private set; }
        public int ContatoPrincipalId { get; private set; }
        public string NomeAmigo { get; private set; }
        public string EmailAmigo { get; private set; }
        public int ContatoAmigoId { get; private set; }
    }
}
