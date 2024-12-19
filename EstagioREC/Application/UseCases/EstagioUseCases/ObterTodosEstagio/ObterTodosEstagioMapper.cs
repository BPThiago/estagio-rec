using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;

public sealed class ObterTodosEstagioMapper : Profile
{
    public ObterTodosEstagioMapper()
    {
        CreateMap<Estagio, EstagioResponse>();
    }
}