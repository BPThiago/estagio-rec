using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterEmpresa;

public sealed class ObterEmpresaMapper : Profile
{
    public ObterEmpresaMapper()
    {
        CreateMap<ObterEmpresaRequest, Empresa>();
        CreateMap<Empresa, EmpresaResponse>();
    }
}