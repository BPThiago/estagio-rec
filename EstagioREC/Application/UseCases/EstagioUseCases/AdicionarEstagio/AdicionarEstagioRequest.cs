using EstagioREC.Application.DTOs;
using EstagioREC.Domain.Enums;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.AdicionarEstagio;

public sealed record AdicionarEstagioRequest(
    DateTime DatIni, DateTime DatFim, SituacaoEnum Situacao, int EmpresaId, int OrientadorId, int AlunoId 
    ) : IRequest<EstagioResponse>;