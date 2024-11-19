namespace EstagioREC.Model
{
    public class Orientador {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public Orientador() { }

        public Orientador(OrientadorDTO orientadorDTO)
        {
            Id = orientadorDTO.Id;
            Nome = orientadorDTO.Nome;
            Email = orientadorDTO.Email;
            Telefone = orientadorDTO.Telefone;
        }
    }
}