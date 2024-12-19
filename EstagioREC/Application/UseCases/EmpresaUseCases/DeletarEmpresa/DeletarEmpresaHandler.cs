using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.DeletarEmpresa;

public class DeletarEmpresaHandler : DeletarHandler<
        DeletarEmpresaRequest,
        EmpresaResponse,
        Empresa,
        IEmpresaRepository
    >
{
    public DeletarEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper) : base(empresaRepository, mapper)
    {
    }
}