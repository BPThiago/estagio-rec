using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterTodosEmpresa;

public sealed class ObterTodosEmpresaMapper : Profile
{
    
    public ObterTodosEmpresaMapper()
    {
        CreateMap<Empresa, EmpresaResponse>();
    }
}