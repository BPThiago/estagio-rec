using EstagioREC.Persistence.Repository.Interfaces;
using AutoMapper;
using MediatR;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterTodosEmpresa;

public sealed class ObterTodosEmpresaHandler : IRequestHandler<ObterTodosEmpresaRequest, List<ObterTodosEmpresaResponse>>
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IMapper _mapper;

    public ObterTodosEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository;
        _mapper = mapper;
    }

    public async Task<List<ObterTodosEmpresaResponse>> Handle(ObterTodosEmpresaRequest request, CancellationToken cancellationToken)
    {
        var empresas = await _empresaRepository.ObterTodosAsync(cancellationToken);
        return _mapper.Map<List<ObterTodosEmpresaResponse>>(empresas);
    }
}