using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.DeletarEmpresa;

public class DeletarEmpresaHandler : IRequestHandler<DeletarEmpresaRequest, EmpresaResponse>
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IMapper _mapper;

    public DeletarEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository;
        _mapper = mapper;
    }

    public async Task<EmpresaResponse> Handle(DeletarEmpresaRequest request,
        CancellationToken cancellationToken)
    {
        var empresa = await _empresaRepository.ObterPorIdAsync(request.Id, cancellationToken);

        if (empresa is null)
            return default;
        
        await _empresaRepository.DeletarAsync(empresa, cancellationToken);
        
        return _mapper.Map<EmpresaResponse>(empresa);
    }
}