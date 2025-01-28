using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.AlunoUseCases.AtualizarAluno;

public class AtualizarAlunoMapper : Profile
{
    public AtualizarAlunoMapper()
    {
        CreateMap<AtualizarAlunoRequest, Aluno>();
        CreateMap<Aluno, AlunoResponse>();
    }
}