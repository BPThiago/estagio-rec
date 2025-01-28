using EstagioREC.Application.DTOs;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.DeletarAluno;

public sealed record DeletarAlunoRequest(
    int Id
) : IRequest<AlunoResponse>;