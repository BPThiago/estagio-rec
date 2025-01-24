using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.AlunoUseCases.ObterAluno;

public class ObterAlunoMapper : Profile
{
    public ObterAlunoMapper()
    {
        CreateMap<ObterAlunoRequest, Aluno>();
        CreateMap<Aluno, AlunoResponse>();
    }
}