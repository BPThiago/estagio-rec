using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterEmpresa;

public sealed class ObterEmpresaMapper : Profile
{
    public ObterEmpresaMapper()
    {
        CreateMap<Empresa, EmpresaResponse>();
    }
}