using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.ObterTodosAluno;

public class ObterTodosAlunoHandler  : ObterTodosHandler<
        ObterTodosAlunoRequest,
        AlunoResponse,
        Aluno,
        IAlunoRepository
    >
{
    public ObterTodosAlunoHandler(IAlunoRepository alunoRepository, IMapper mapper) : base(alunoRepository, mapper)
    {
    }
}