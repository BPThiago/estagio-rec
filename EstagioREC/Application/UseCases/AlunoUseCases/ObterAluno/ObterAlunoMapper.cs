using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.AlunoUseCases.ObterAluno;

public class ObterAlunoMapper : Profile
{
    public ObterAlunoMapper()
    {
        CreateMap<Aluno, AlunoResponse>();
    }
}