using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterTodosOrientador;

public sealed class ObterTodosOrientadorMapper : Profile
{
    
    public ObterTodosOrientadorMapper()
    {
        CreateMap<Orientador, OrientadorResponse>();
    }
}