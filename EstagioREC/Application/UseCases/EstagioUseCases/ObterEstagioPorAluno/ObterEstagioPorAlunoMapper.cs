using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorAluno;

public sealed class ObterEstagioPorAlunoMapper : Profile
{
    public ObterEstagioPorAlunoMapper()
    {
        CreateMap<Estagio, EstagioResponse>();
    }
}