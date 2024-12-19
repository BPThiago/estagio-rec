using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.AtualizarOrientador;

public class AtualizarOrientadorMapper : Profile
{
    public AtualizarOrientadorMapper()
    {
        CreateMap<AtualizarOrientadorRequest, Orientador>();
        CreateMap<Orientador, OrientadorResponse>();
    }
}