using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorEmpresa;

public sealed class ObterEstagioPorEmpresaMapper : Profile
{
    public ObterEstagioPorEmpresaMapper()
    {
        CreateMap<Estagio, EstagioResponse>();
    }
}