using EstagioREC.Persistence.Repository.Interfaces;
using AutoMapper;
using MediatR;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterTodosOrientador;

public sealed class ObterTodosOrientadorHandler : IRequestHandler<ObterTodosOrientadorRequest, List<ObterTodosOrientadorResponse>>
{
    private readonly IOrientadorRepository _orientadorRepository;
    private readonly IMapper _mapper;

    public ObterTodosOrientadorHandler(IOrientadorRepository orientadorRepository, IMapper mapper)
    {
        _orientadorRepository = orientadorRepository;
        _mapper = mapper;
    }

    public async Task<List<ObterTodosOrientadorResponse>> Handle(ObterTodosOrientadorRequest request, CancellationToken cancellationToken)
    {
        var orientadores = await _orientadorRepository.ObterTodosAsync(cancellationToken);
        return _mapper.Map<List<ObterTodosOrientadorResponse>>(orientadores);
    }
}