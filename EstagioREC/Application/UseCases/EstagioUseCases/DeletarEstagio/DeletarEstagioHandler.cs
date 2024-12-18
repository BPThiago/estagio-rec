using AutoMapper;
using EstagioREC.Application.UseCases.EstagioUseCases.DeletarEstagio;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.DeletarEstagio;

public class DeletarEstagioHandler : IRequestHandler<DeletarEstagioRequest, DeletarEstagioResponse>
{
    private readonly IEstagioRepository _estagioRepository;
    private readonly IMapper _mapper;

    public DeletarEstagioHandler(IEstagioRepository estagioRepository, IMapper mapper)
    {
        _estagioRepository = estagioRepository;
        _mapper = mapper;
    }

    public async Task<DeletarEstagioResponse> Handle(DeletarEstagioRequest request,
        CancellationToken cancellationToken)
    {
        var estagio = await _estagioRepository.ObterPorIdAsync(request.Id, cancellationToken);
        
        if (estagio == null)
            return default;
        
        await _estagioRepository.DeletarAsync(estagio, cancellationToken);
        return _mapper.Map<DeletarEstagioResponse>(estagio);
    }
}