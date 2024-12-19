using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.AtualizarEmpresa;

public class AtualizarEmpresaHandler : AtualizarHandler<
        AtualizarEmpresaRequest,
        EmpresaResponse,
        Empresa,
        IEmpresaRepository
    >
{
    public AtualizarEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper) : base(empresaRepository, mapper)
    {
    }
}