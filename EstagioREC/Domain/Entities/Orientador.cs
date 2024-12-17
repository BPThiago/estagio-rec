namespace EstagioREC.Domain
{
    public class Orientador : BaseEntity
    {
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public ICollection<Estagio> Estagios;
    }
}