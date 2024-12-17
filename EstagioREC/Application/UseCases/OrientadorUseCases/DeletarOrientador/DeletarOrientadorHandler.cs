using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.DeletarOrientador;

public class DeletarOrientadorHandler : IRequestHandler<DeletarOrientadorRequest, DeletarOrientadorResponse>
{
    private readonly IOrientadorRepository _orientadorRepository;
    private readonly IMapper _mapper;

    public DeletarOrientadorHandler(IOrientadorRepository orientadorRepository, IMapper mapper)
    {
        _orientadorRepository = orientadorRepository;
        _mapper = mapper;
    }

    public async Task<DeletarOrientadorResponse> Handle(DeletarOrientadorRequest request,
        CancellationToken cancellationToken)
    {
        var orientador = await _orientadorRepository.ObterPorIdAsync(request.Id);

        if (orientador is null)
            return default;
        
        await _orientadorRepository.DeletarAsync(orientador);
        
        return _mapper.Map<DeletarOrientadorResponse>(orientador);
    }
}