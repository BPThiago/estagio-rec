using AutoMapper;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagio;

public sealed class ObterEstagioHandle : IRequestHandler<ObterEstagioRequest, ObterEstagioResponse>
{
    private readonly IEstagioRepository _estagioRepository;
    private readonly IMapper _mapper;

    public ObterEstagioHandle(IEstagioRepository estagioRepository, IMapper mapper)
    {
        _estagioRepository = estagioRepository;
        _mapper = mapper;
    }
    
    public async Task<ObterEstagioResponse> Handle(ObterEstagioRequest request, CancellationToken cancellationToken)
    {
        var estagio = await _estagioRepository.ObterPorIdAsync(request.Id, cancellationToken);
        return _mapper.Map<ObterEstagioResponse>(estagio);
    }
}
