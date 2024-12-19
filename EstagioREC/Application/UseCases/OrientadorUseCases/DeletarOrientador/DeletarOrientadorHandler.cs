using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.DeletarOrientador;

public class DeletarOrientadorHandler : IRequestHandler<DeletarOrientadorRequest, OrientadorResponse>
{
    private readonly IOrientadorRepository _orientadorRepository;
    private readonly IMapper _mapper;

    public DeletarOrientadorHandler(IOrientadorRepository orientadorRepository, IMapper mapper)
    {
        _orientadorRepository = orientadorRepository;
        _mapper = mapper;
    }

    public async Task<OrientadorResponse> Handle(DeletarOrientadorRequest request,
        CancellationToken cancellationToken)
    {
        var orientador = await _orientadorRepository.ObterPorIdAsync(request.Id, cancellationToken);

        if (orientador is null)
            return default;
        
        await _orientadorRepository.DeletarAsync(orientador, cancellationToken);
        
        return _mapper.Map<OrientadorResponse>(orientador);
    }
}