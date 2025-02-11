using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain.Enums;

namespace EstagioREC.Application.DTOs
{
    public sealed record EstagioResponse : BaseResponse
    {
        public DateTime? DatIni { get; set; }
        public DateTime? DatFim { get; set; }
        public SituacaoEnum Situacao { get; set; }
        public int EmpresaId { get; set; }
        public int OrientadorId { get; set; }
        public int AlunoId { get; set; }
    }
}
