using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.AlunoUseCases.ObterAluno;

public class ObterAlunoMapper : Profile
{
    public ObterAlunoMapper()
    {
        CreateMap<Aluno, ObterAlunoResponse>();
    }
}