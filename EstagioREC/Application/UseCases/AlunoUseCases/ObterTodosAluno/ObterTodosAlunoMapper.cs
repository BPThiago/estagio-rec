using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.AlunoUseCases.ObterTodosAluno;

public sealed class ObterTodosAlunoMapper : Profile
{
    public ObterTodosAlunoMapper()
    {
        CreateMap<Aluno, ObterTodosAlunoResponse>();
    }
}
