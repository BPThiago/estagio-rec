using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.DeletarEmpresa;

public class DeletarEmpresaMapper : Profile
{
    
    public DeletarEmpresaMapper()
    {
        CreateMap<DeletarEmpresaRequest, Empresa>();
        CreateMap<Empresa, EmpresaResponse>();
    }
}