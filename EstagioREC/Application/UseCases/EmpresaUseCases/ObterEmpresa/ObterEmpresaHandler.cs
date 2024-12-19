using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterEmpresa;

public sealed class ObterEmpresaHandler : IRequestHandler<ObterEmpresaRequest, EmpresaResponse>
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IMapper _mapper;

    public ObterEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository;
        _mapper = mapper;
    }

    public async Task<EmpresaResponse> Handle(ObterEmpresaRequest request, CancellationToken cancellationToken)
    {
        var empresa = await _empresaRepository.ObterPorIdAsync(request.Id, cancellationToken);
        return _mapper.Map<EmpresaResponse>(empresa);
    }
}