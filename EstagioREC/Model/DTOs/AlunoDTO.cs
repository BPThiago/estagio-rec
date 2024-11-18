namespace EstagioREC.Model
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        
        public AlunoDTO(int id, string nome, string matricula)
        {
            Id = id;
            Nome = nome;
            Matricula = matricula;
        }
    }
    

}
