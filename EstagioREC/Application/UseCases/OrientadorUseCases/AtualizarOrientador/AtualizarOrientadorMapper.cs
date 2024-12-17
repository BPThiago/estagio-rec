using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.AtualizarOrientador;

public class AtualizarOrientadorMapper : Profile
{
    public AtualizarOrientadorMapper()
    {
        CreateMap<AtualizarOrientadorRequest, Orientador>();
        CreateMap<Orientador, AtualizarOrientadorResponse>();
    }
}