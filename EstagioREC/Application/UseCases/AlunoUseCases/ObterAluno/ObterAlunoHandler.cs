using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;

namespace EstagioREC.Application.UseCases.AlunoUseCases.ObterAluno;

public class ObterAlunoHandler  : ObterHandler<
        ObterAlunoRequest,
        AlunoResponse,
        Aluno,
        IAlunoRepository
    >
{
    public ObterAlunoHandler(IAlunoRepository alunoRepository, IMapper mapper) : base(alunoRepository, mapper)
    {
    }
}