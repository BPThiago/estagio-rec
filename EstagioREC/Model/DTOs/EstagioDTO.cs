namespace EstagioREC.Model.DTOs
{
    public class EstagioDTO
    {
        public int Id { get; set; }
        public DateTime DatIni { get; set; }
        public DateTime DatFim { get; set; }
        public SituacaoEnum Situacao { get; set; }
        public int EmpresaId {get; set; }
        public int OrientadorId { get; set; }
        public int AlunoId { get; set; }
        
        public EstagioDTO(int id, DateTime datIni, DateTime datFim, SituacaoEnum situacao, int alunoId, int orientadorId, int empresaId)
        {
            Id = id;
            this.DatIni = datIni;
            this.DatFim = datFim;
            this.Situacao = situacao;
            this.AlunoId = alunoId;
            this.OrientadorId = orientadorId;
            this.EmpresaId = empresaId;
        }
    }
}
