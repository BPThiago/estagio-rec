namespace EstagioREC.Model;

public class EmpresaDTO
{
    public int id { get; set; }
    public string Nome { get; set; }
    public List<Estagio> estagios { get; set; }
        
    public EmpresaDTO(int Id, string nome, List<Estagio> estagios)
    {
        id = Id;
        this.Nome = nome;
        foreach (Estagio estagio in estagios)
        {
            this.estagios.Add(estagio);
        }
    }
}