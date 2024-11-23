using EstagioREC.Model.DTOs;

namespace EstagioREC.Model
{
    public class Empresa
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public ICollection<Estagio> Estagios;

        public Empresa() { }

        public Empresa(EmpresaDTO empresaDTO)
        {
            Id = empresaDTO.Id;
            Nome = empresaDTO.Nome;
            Estagios = new List<Estagio>();
        }
    }
}