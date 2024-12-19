using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterOrientador;

public sealed class ObterOrientadorMapper : Profile
{
    public ObterOrientadorMapper()
    {
        CreateMap<ObterOrientadorRequest, Orientador>();
        CreateMap<Orientador, OrientadorResponse>();
    }
}