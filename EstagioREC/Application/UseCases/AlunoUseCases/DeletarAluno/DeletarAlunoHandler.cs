using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.DeletarAluno;

public class DeletarAlunoHandler : DeletarHandler<
        DeletarAlunoRequest,
        AlunoResponse,
        Aluno,
        IAlunoRepository
    >
{
    public DeletarAlunoHandler(IAlunoRepository alunoRepository, IMapper mapper) : base(alunoRepository, mapper)
    {
    }
}