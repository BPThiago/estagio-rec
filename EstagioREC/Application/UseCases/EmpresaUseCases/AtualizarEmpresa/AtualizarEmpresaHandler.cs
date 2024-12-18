using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.AtualizarEmpresa;

public class AtualizarEmpresaHandler : IRequestHandler<AtualizarEmpresaRequest, AtualizarEmpresaResponse>
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IMapper _mapper;

    public AtualizarEmpresaHandler(IEmpresaRepository empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository;
        _mapper = mapper;
    }

    public async Task<AtualizarEmpresaResponse> Handle(AtualizarEmpresaRequest request,
        CancellationToken cancellationToken)
    {
        var empresa = await _empresaRepository.ObterPorIdAsync(request.Id, cancellationToken);

        if (empresa is null)
            return default;
        
        empresa.Nome = request.Nome;

        await _empresaRepository.AtualizarAsync(empresa, cancellationToken);
        
        return _mapper.Map<AtualizarEmpresaResponse>(empresa);
    }
}