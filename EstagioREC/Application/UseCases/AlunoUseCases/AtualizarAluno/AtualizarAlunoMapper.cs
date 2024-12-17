using AutoMapper;
using EstagioREC.Application.UseCases.AlunoUseCases.AtualizarAluno;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.AlunoUseCases.AtualizarAluno;

public class AtualizarAlunoMapper : Profile
{
    public AtualizarAlunoMapper()
    {
        CreateMap<AtualizarAlunoRequest, Aluno>();
        CreateMap<Aluno, AtualizarAlunoResponse>();
    }
}