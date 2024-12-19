using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterEmpresa;

public sealed class ObterEmpresaHandler : ObterHandler<
        ObterEmpresaRequest,
        EmpresaResponse,
        Empresa,
        IEmpresaRepository
    >
{
    public ObterEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper) : base(empresaRepository, mapper)
    {
    }
}