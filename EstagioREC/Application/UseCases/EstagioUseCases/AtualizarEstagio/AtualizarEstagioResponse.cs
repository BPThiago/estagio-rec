using EstagioREC.Domain.Enums;

namespace EstagioREC.Application.UseCases.EstagioUseCases.AtualizarEstagio;

public class AtualizarEstagioResponse
{
    public int Id { get; set; }
    public DateTime DatIni { get; set; }
    public DateTime DatFim { get; set; }
    public SituacaoEnum Situacao { get; set; }
    public int EmpresaId {get; set; }
    public int OrientadorId { get; set; }
    public int AlunoId { get; set; }
}