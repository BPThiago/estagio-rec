namespace EstagioREC.Model;

public class EmpresaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
        
    public EmpresaDTO(int Id, string nome)
    {
        Id = Id;
        this.Nome = nome;
    }
}