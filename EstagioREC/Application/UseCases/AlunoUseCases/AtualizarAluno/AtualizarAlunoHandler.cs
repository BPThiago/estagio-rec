using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Application.DTOs;

namespace EstagioREC.Application.UseCases.AlunoUseCases.AtualizarAluno;

public class AtualizarAlunoHandler  : AtualizarHandler<
        AtualizarAlunoRequest,
        AlunoResponse,
        Aluno,
        IAlunoRepository
    >
{
    public AtualizarAlunoHandler(IAlunoRepository alunoRepository, IMapper mapper) : base(alunoRepository, mapper)
    {
    }
}


