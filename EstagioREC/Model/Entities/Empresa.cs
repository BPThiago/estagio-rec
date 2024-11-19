namespace EstagioREC.Model;

public class Empresa
{
    public int id { get; set; }
    public String nome { get; set; }
    public List<Estagio> estagios { get; set; }
}