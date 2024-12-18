using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EstagioUseCases.DeletarEstagio;

public class DeletarEstagioMapper : Profile
{
    public DeletarEstagioMapper()
    {
        CreateMap<DeletarEstagioRequest, Estagio>();
        CreateMap<Estagio, DeletarEstagioResponse>();
    }
}