using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorOrientador;

public sealed class ObterEstagioPorOrientadorMapper : Profile
{
    public ObterEstagioPorOrientadorMapper()
    {
        CreateMap<Estagio, EstagioResponse>();
    }
}