using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.DeletarAluno;

public sealed record DeletarAlunoRequest(
    int Id
) : IRequest<DeletarAlunoResponse>;