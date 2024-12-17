namespace EstagioREC.Domain
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public ICollection<Estagio> Estagios;
    }
}

