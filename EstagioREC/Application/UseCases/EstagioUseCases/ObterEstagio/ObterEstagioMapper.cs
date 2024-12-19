using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagio;

public sealed class ObterEstagioMapper : Profile
{
    public ObterEstagioMapper()
    {
        CreateMap<ObterEstagioRequest, Estagio>();
        CreateMap<Estagio, EstagioResponse>();
    }
}