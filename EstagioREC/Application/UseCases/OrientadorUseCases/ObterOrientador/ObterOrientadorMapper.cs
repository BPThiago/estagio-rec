using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterOrientador;

public sealed class ObterOrientadorMapper : Profile
{
    public ObterOrientadorMapper()
    {
        CreateMap<Orientador, ObterOrientadorResponse>();
    }
}