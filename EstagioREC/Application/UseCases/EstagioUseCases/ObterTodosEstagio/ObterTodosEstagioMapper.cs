using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;

public sealed class ObterTodosEstagioMapper : Profile
{
    public ObterTodosEstagioMapper()
    {
        CreateMap<Estagio, ObterTodosEstagioResponse>();
    }
}