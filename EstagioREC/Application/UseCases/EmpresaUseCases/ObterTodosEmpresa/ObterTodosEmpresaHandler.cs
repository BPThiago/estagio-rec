using EstagioREC.Persistence.Repository.Interfaces;
using AutoMapper;
using MediatR;
using EstagioREC.Application.UseCases.BaseUseCases;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterTodosEmpresa;

public sealed class ObterTodosEmpresaHandler : IRequestHandler<ObterTodosEmpresaRequest, List<EmpresaResponse>>
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IMapper _mapper;

    public ObterTodosEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository;
        _mapper = mapper;
    }

    public async Task<List<EmpresaResponse>> Handle(ObterTodosEmpresaRequest request, CancellationToken cancellationToken)
    {
        var empresas = await _empresaRepository.ObterTodosAsync(cancellationToken);
        return _mapper.Map<List<EmpresaResponse>>(empresas);
    }
}