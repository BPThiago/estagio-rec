using EstagioREC.Model.DTOs;

namespace EstagioREC.Model
{
    public class Empresa
    {
        public int Id { get; set; }
        public String Nome { get; set; }

        public Empresa() { }

        public Empresa(EmpresaDTO empresaDTO)
        {
            Id = empresaDTO.Id;
            Nome = empresaDTO.Nome;
        }
    }
}