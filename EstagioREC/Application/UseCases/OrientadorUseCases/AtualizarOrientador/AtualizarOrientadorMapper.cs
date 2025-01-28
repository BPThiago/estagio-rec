using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.AtualizarOrientador;

public class AtualizarOrientadorMapper : Profile
{
    public AtualizarOrientadorMapper()
    {
        CreateMap<AtualizarOrientadorRequest, Orientador>();
        CreateMap<Orientador, OrientadorResponse>();
    }
}