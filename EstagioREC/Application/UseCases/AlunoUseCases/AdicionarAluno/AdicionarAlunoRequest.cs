using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.AdicionarAluno
{ 
    public sealed record AdicionarAlunoRequest(
        string Nome, string Matricula
        ) : IRequest<AdicionarAlunoResponse>;
}

