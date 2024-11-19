namespace EstagioREC.Model.DTOs
{
    public class EstagioDTO
    {
        public int Id { get; set; }
        public DateTime DatIni { get; set; }
        public DateTime DatFim { get; set; }
        public int Situacao { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public OrientadorDTO Orientador { get; set; }
        public AlunoDTO Aluno { get; set; }
        
        public EstagioDTO(int id, DateTime datIni, DateTime datFim, int situacao, EmpresaDTO empresa, OrientadorDTO orientador, AlunoDTO aluno)
        {
            Id = id;
            this.DatIni = datIni;
            this.DatFim = datFim;
            this.Situacao = situacao;
            this.Empresa = empresa;
            this.Orientador = orientador;
            this.Aluno = aluno;
        }
    }
}
