using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.ObterTodosAluno
{
    public sealed record ObterTodosAlunoRequest 
        : IRequest<List<ObterTodosAlunoResponse>>;
}