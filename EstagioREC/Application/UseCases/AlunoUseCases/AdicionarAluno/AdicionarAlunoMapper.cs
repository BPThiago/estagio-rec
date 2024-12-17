using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.AlunoUseCases.AdicionarAluno;

public sealed class AdicionarAlunoMapper : Profile
{
    public AdicionarAlunoMapper()
    {
        CreateMap<AdicionarAlunoRequest, Aluno>();
        CreateMap<Aluno, AdicionarAlunoResponse>();
    }
}