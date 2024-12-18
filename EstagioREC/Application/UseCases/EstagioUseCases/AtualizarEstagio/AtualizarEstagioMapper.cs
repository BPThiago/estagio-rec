using AutoMapper;
using EstagioREC.Domain;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.AtualizarEstagio;

public class AtualizarEstagioMapper : Profile
{
    public AtualizarEstagioMapper()
    {
        CreateMap<AtualizarEstagioRequest, Estagio>();
        CreateMap<Estagio, AtualizarEstagioResponse>();
    }
}