using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.DeletarOrientador;

public class DeletarOrientadorMapper : Profile
{
    
    public DeletarOrientadorMapper()
    {
        CreateMap<DeletarOrientadorRequest, Orientador>();
        CreateMap<Orientador, DeletarOrientadorResponse>();
    }
}