
namespace Chat.Domain.Contatos.Entities
{
    public class Contato
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string FotoUrl { get; private set; }

        public Contato() { }
    }
}
