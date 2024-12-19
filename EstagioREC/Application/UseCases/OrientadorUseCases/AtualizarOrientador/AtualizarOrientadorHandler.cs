using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.AtualizarOrientador;

public class AtualizarOrientadorHandler : IRequestHandler<AtualizarOrientadorRequest, OrientadorResponse>
{
    private readonly IOrientadorRepository _orientadorRepository;
    private readonly IMapper _mapper;

    public AtualizarOrientadorHandler(IOrientadorRepository orientadorRepository, IMapper mapper)
    {
        _orientadorRepository = orientadorRepository;
        _mapper = mapper;
    }

    public async Task<OrientadorResponse> Handle(AtualizarOrientadorRequest request,
        CancellationToken cancellationToken)
    {
        var orientador = await _orientadorRepository.ObterPorIdAsync(request.Id, cancellationToken);

        if (orientador is null)
            return default;
        
        orientador.Nome = request.Nome;
        orientador.Email = request.Email;
        orientador.Telefone = request.Telefone;

        await _orientadorRepository.AtualizarAsync(orientador, cancellationToken);
        
        return _mapper.Map<OrientadorResponse>(orientador);
    }
}