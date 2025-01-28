using EstagioREC.Application.DTOs;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.ObterAluno;

public sealed record ObterAlunoRequest(
    int Id
) : IRequest <AlunoResponse>;
