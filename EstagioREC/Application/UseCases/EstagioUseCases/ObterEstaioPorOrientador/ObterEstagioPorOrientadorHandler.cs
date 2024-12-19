using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorOrientador;

public class ObterEstagioPorOrientadorHandler : IRequestHandler<ObterEstagioPorOrientadorRequest, List<EstagioResponse>>
{
    private readonly IEstagioRepository _estagioRepository;
    private readonly IMapper _mapper;

    public ObterEstagioPorOrientadorHandler(IEstagioRepository estagioRepository, IMapper mapper)
    {
        _estagioRepository = estagioRepository;
        _mapper = mapper;
    }

    public async Task<List<EstagioResponse>> Handle(ObterEstagioPorOrientadorRequest request, CancellationToken cancellationToken)
    {
        var estagios = await _estagioRepository.ObterPorOrientadorAsync(request.OrientadorId, cancellationToken);
        return _mapper.Map<List<EstagioResponse>>(estagios);
    } 
}
