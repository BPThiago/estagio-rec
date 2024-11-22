namespace EstagioREC.Model.DTOs 
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
            
        public EmpresaDTO(int id, string nome)
        {
            Id = id;
            this.Nome = nome;
        }
    }
}