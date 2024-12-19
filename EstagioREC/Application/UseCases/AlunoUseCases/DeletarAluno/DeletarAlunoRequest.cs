using EstagioREC.Application.UseCases.BaseUseCases;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.DeletarAluno;

public sealed record DeletarAlunoRequest(
    int Id
) : IRequest<AlunoResponse>;