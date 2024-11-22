namespace EstagioREC.Model
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public ICollection<Estagio> Estagios;

        public Aluno() { }

        public Aluno(AlunoDTO alunoDTO)
        {
            Id = alunoDTO.Id;
            Nome = alunoDTO.Nome;
            Matricula = alunoDTO.Matricula;
            Estagios = new List<Estagio>();
        }
    }
}

