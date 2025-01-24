using EstagioREC.Persistence.Repository.Interfaces;
using AutoMapper;
using MediatR;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Application.DTOs;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterTodosEmpresa;

public sealed class ObterTodosEmpresaHandler : ObterTodosHandler<
        ObterTodosEmpresaRequest,
        EmpresaResponse,
        Empresa,
        IEmpresaRepository
    >
{
    public ObterTodosEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper) : base(empresaRepository, mapper)
    {
    }
}