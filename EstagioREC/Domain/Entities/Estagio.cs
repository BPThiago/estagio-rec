using EstagioREC.Domain.Enums;

namespace EstagioREC.Domain
{
    public class Estagio : BaseEntity
    {
        public DateTime? DatIni { get; set; }
        public DateTime? DatFim { get; set; }
        public SituacaoEnum Situacao { get; set; }
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
        public Orientador Orientador { get; set; }
        public int OrientadorId { get; set; }
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
    }
}
    