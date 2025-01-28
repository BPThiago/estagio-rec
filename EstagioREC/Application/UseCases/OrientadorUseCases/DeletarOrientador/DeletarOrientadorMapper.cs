using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.DeletarOrientador;

public class DeletarOrientadorMapper : Profile
{
    
    public DeletarOrientadorMapper()
    {
        CreateMap<DeletarOrientadorRequest, Orientador>();
        CreateMap<Orientador, OrientadorResponse>();
    }
}