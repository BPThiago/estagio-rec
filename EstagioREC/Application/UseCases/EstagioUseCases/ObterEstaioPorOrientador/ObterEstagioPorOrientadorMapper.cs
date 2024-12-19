using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorOrientador;

public sealed class ObterEstagioPorOrientadorMapper : Profile
{
    public ObterEstagioPorOrientadorMapper()
    {
        CreateMap<Estagio, EstagioResponse>();
    }
}