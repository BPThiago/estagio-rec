using AutoMapper;
using EstagioREC.Application.UseCases.EstagioUseCases.AtualizarEstagio;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagio;

public sealed class ObterEstagioMapper : Profile
{
    public ObterEstagioMapper()
    {
        CreateMap<Estagio, ObterEstagioResponse>();
    }
}