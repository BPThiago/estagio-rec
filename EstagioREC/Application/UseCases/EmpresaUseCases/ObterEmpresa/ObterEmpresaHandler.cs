using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterEmpresa;

public sealed class ObterEmpresaHandler : IRequestHandler<ObterEmpresaRequest, ObterEmpresaResponse>
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IMapper _mapper;

    public ObterEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository;
        _mapper = mapper;
    }

    public async Task<ObterEmpresaResponse> Handle(ObterEmpresaRequest request, CancellationToken cancellationToken)
    {
        var empresa = await _empresaRepository.ObterPorIdAsync(request.Id, cancellationToken);
        return _mapper.Map<ObterEmpresaResponse>(empresa);
    }
}