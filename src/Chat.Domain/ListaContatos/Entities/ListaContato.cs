using Chat.Domain.Contatos.Entities;

namespace Chat.Domain.ListaContatos.Entities
{
    public class ListaContato
    {
        public int Id { get; private set; }
        public int ContatoPrincipalId { get; private set; }
        public virtual Contato ContatoPrincipal { get; private set; }
        public int ContatoAmigoId { get; private set; }
        public virtual Contato ContatoAmigo { get; private set; }

        public ListaContato() { }

        public ListaContato(
            int contatoPrincipalId,
            int contatoAmigoId)
        {
            ContatoPrincipalId = contatoPrincipalId;
            ContatoAmigoId = contatoAmigoId;
        }
    }
}
