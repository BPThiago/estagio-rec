using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterOrientador;

public sealed class ObterOrientadorHandler : IRequestHandler<ObterOrientadorRequest, ObterOrientadorResponse>
{
    private readonly IOrientadorRepository _orientadorRepository;
    private readonly IMapper _mapper;

    public ObterOrientadorHandler(IOrientadorRepository orientadorRepository, IMapper mapper)
    {
        _orientadorRepository = orientadorRepository;
        _mapper = mapper;
    }

    public async Task<ObterOrientadorResponse> Handle(ObterOrientadorRequest request, CancellationToken cancellationToken)
    {
        var orientador = await _orientadorRepository.ObterPorIdAsync(request.Id, cancellationToken);
        return _mapper.Map<ObterOrientadorResponse>(orientador);
    }
}