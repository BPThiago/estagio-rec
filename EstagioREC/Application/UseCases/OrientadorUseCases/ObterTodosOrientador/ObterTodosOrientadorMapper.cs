using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterTodosOrientador;

public sealed class ObterTodosOrientadorMapper : Profile
{
    
    public ObterTodosOrientadorMapper()
    {
        CreateMap<Orientador, ObterTodosOrientadorResponse>();
    }
}