using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EstagioUseCases.AdicionarEstagio;

public sealed class AdicionarEstagioMapper : Profile
{
    public AdicionarEstagioMapper()
    {
        CreateMap<AdicionarEstagioRequest, Estagio>();
        CreateMap<Estagio, EstagioResponse>();
    }
}