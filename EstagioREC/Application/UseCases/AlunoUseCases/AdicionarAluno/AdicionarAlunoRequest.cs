using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.AdicionarAluno
{ 
    public sealed record AdicionarAlunoRequest(
        string nome, string matricula
        ) : IRequest<AdicionarAlunoResponse>;
}

