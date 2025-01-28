using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagio;

public sealed class ObterEstagioMapper : Profile
{
    public ObterEstagioMapper()
    {
        CreateMap<ObterEstagioRequest, Estagio>();
        CreateMap<Estagio, EstagioResponse>();
    }
}