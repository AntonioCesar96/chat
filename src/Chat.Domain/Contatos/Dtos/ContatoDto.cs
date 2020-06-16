namespace Chat.Domain.Contatos.Dtos
{
    public class ContatoDto
    {
        public int ContatoId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string FotoUrl { get; set; }
    }
}
