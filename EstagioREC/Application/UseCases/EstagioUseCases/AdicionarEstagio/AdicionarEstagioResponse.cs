using EstagioREC.Domain.Enums;

namespace EstagioREC.Application.UseCases.EstagioUseCases.AdicionarEstagio;

public sealed record AdicionarEstagioResponse
{
    public int Id { get; set; }
    public DateTime DatIni { get; set; }
    public DateTime DatFim { get; set; }
    public SituacaoEnum Situacao { get; set; }
    public int EmpresaId {get; set; }
    public int OrientadorId { get; set; }
    public int AlunoId { get; set; }
}