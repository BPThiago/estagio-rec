using EstagioREC.Application.UseCases.AlunoUseCases.AtualizarAluno;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.AtualizarAluno {
    public sealed record AtualizarAlunoRequest(
        int Id,
        string Nome,
        string Matricula
    ) : IRequest<AtualizarAlunoResponse>;
}