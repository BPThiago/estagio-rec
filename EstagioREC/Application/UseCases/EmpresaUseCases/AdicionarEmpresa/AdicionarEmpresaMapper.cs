using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.AdicionarEmpresa;

public sealed class AdicionarEmpresaMapper : Profile
{
    public AdicionarEmpresaMapper()
    {
        CreateMap<AdicionarEmpresaRequest, Empresa>();
        CreateMap<Empresa, EmpresaResponse>();
    }
}