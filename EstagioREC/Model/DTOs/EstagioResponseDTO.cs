namespace EstagioREC.Model.DTOs
{
    public class EstagioResponseDTO
    {
        public int Id { get; set; }
        public DateTime DatIni { get; set; }
        public DateTime DatFim { get; set; }
        public SituacaoEnum Situacao { get; set; }
        public AlunoDTO AlunoDTO { get; set; }
        public OrientadorDTO OrientadorDTO { get; set; }
        public EmpresaDTO EmpresaDTO { get; set; }

        public EstagioResponseDTO(int id, DateTime datIni, DateTime datFim, SituacaoEnum situacao, AlunoDTO alunoDTO, OrientadorDTO orientadorDTO, EmpresaDTO empresaDTO)
        {
            Id = id;
            this.DatIni = datIni;
            this.DatFim = datFim;
            this.Situacao = situacao;
            this.AlunoDTO = alunoDTO;
            this.OrientadorDTO= orientadorDTO;
            this.EmpresaDTO = empresaDTO;
        }
    }
}
