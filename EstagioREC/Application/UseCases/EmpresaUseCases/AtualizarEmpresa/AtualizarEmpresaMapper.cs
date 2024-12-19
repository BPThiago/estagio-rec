using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.AtualizarEmpresa;

public class AtualizarEmpresaMapper : Profile
{
    public AtualizarEmpresaMapper()
    {
        CreateMap<AtualizarEmpresaRequest, Empresa>();
        CreateMap<Empresa, EmpresaResponse>();
    }
}