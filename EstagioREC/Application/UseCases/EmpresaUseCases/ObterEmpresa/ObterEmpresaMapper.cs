using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterEmpresa;

public sealed class ObterEmpresaMapper : Profile
{
    public ObterEmpresaMapper()
    {
        CreateMap<Empresa, ObterEmpresaResponse>();
    }
}