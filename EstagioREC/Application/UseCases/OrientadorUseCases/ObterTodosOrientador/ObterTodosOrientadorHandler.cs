using EstagioREC.Persistence.Repository.Interfaces;
using AutoMapper;
using MediatR;
using EstagioREC.Application.UseCases.BaseUseCases;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterTodosOrientador;

public sealed class ObterTodosOrientadorHandler : IRequestHandler<ObterTodosOrientadorRequest, List<OrientadorResponse>>
{
    private readonly IOrientadorRepository _orientadorRepository;
    private readonly IMapper _mapper;

    public ObterTodosOrientadorHandler(IOrientadorRepository orientadorRepository, IMapper mapper)
    {
        _orientadorRepository = orientadorRepository;
        _mapper = mapper;
    }

    public async Task<List<OrientadorResponse>> Handle(ObterTodosOrientadorRequest request, CancellationToken cancellationToken)
    {
        var orientadores = await _orientadorRepository.ObterTodosAsync(cancellationToken);
        return _mapper.Map<List<OrientadorResponse>>(orientadores);
    }
}