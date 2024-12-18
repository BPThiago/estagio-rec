using AutoMapper;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.DeletarEmpresa;

public class DeletarEmpresaMapper : Profile
{
    
    public DeletarEmpresaMapper()
    {
        CreateMap<DeletarEmpresaRequest, Empresa>();
        CreateMap<Empresa, DeletarEmpresaResponse>();
    }
}