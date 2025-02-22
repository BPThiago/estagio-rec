using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.AlunoUseCases.DeletarAluno;

public class DeletarAlunoMapper : Profile
{
    public DeletarAlunoMapper()
    {
        CreateMap<DeletarAlunoRequest, Aluno>();
        CreateMap<Aluno, AlunoResponse>();
    }
}