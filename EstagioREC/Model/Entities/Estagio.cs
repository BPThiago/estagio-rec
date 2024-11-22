using EstagioREC.Model.DTOs;

namespace EstagioREC.Model
{
    public class Estagio
    {
        public int Id { get; set; }
        public DateTime DatIni { get; set; }
        public DateTime DatFim { get; set; }
        public SituacaoEnum Situacao { get; set; }
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
        public Orientador Orientador { get; set; }
        public int OrientadorId { get; set; }
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }

        public Estagio() { }

        public Estagio(EstagioDTO estagioDTO)
        {
            Id = estagioDTO.Id;
            DatIni = estagioDTO.DatIni;
            DatFim = estagioDTO.DatFim;
            Situacao = estagioDTO.Situacao;
            AlunoId = estagioDTO.AlunoId;
            OrientadorId = estagioDTO.OrientadorId;
            EmpresaId = estagioDTO.EmpresaId;
        }
    }
}
    