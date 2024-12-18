using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.AdicionarEmpresa;

public sealed class AdicionarEmpresaMapper : Profile
{
    public AdicionarEmpresaMapper()
    {
        CreateMap<AdicionarEmpresaRequest, Empresa>();
        CreateMap<Empresa, AdicionarEmpresaResponse>();
    }
}