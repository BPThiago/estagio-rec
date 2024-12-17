namespace EstagioREC.Domain
{
    public class Empresa : BaseEntity
    {
        public String Nome { get; set; }
        public ICollection<Estagio> Estagios;
    }
}