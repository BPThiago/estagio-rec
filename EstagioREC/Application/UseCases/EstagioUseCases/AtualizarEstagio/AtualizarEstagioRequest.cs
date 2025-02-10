using EstagioREC.Application.DTOs;
using EstagioREC.Domain.Enums;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.AtualizarEstagio;

public sealed record AtualizarEstagioRequest(
    int Id, DateTime DatIni, DateTime DatFim, SituacaoEnum Situacao, int EmpresaId, int OrientadorId, int AlunoId 
) : IRequest<EstagioResponse>;