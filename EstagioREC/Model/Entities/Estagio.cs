using EstagioREC.Model.DTOs;

namespace EstagioREC.Model
{
    public class Estagio
    {
        public int Id { get; set; }
        public DateTime DatIni { get; set; }
        public DateTime DatFim { get; set; }
        public int Situacao { get; set; }
        public Aluno Aluno { get; set; }
        public Orientador Orientador { get; set; }
        public Empresa Empresa { get; set; }

        public Estagio() { }

        public Estagio(EstagioDTO estagioDTO)
        {
            Id = estagioDTO.Id;
            DatIni = estagioDTO.DatIni;
            DatFim = estagioDTO.DatFim;
            Situacao = estagioDTO.Situacao;
            Aluno = new Aluno(estagioDTO.Aluno);
            Orientador = new Orientador(estagioDTO.Orientador);
            Empresa = new Empresa(estagioDTO.Empresa);
        }
    }
}