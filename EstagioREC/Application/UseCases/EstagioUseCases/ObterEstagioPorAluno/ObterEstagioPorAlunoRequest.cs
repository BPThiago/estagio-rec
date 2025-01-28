using EstagioREC.Application.DTOs;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorAluno;

public sealed record ObterEstagioPorAlunoRequest
(
    int AlunoId
) : IRequest<List<EstagioResponse>>;