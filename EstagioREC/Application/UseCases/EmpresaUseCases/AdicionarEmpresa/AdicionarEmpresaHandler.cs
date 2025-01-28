using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.AdicionarEmpresa
{
    public class AdicionarEmpresaHandler : AdicionarHandler<
        AdicionarEmpresaRequest,
        EmpresaResponse,
        Empresa,
        IEmpresaRepository
    >
    {
        public AdicionarEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper) : base(empresaRepository, mapper)
        {
        }
    }
}