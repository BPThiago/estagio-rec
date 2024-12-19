using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterOrientador;

public sealed class ObterOrientadorHandler : IRequestHandler<ObterOrientadorRequest, OrientadorResponse>
{
    private readonly IOrientadorRepository _orientadorRepository;
    private readonly IMapper _mapper;

    public ObterOrientadorHandler(IOrientadorRepository orientadorRepository, IMapper mapper)
    {
        _orientadorRepository = orientadorRepository;
        _mapper = mapper;
    }

    public async Task<OrientadorResponse> Handle(ObterOrientadorRequest request, CancellationToken cancellationToken)
    {
        var orientador = await _orientadorRepository.ObterPorIdAsync(request.Id, cancellationToken);
        return _mapper.Map<OrientadorResponse>(orientador);
    }
}