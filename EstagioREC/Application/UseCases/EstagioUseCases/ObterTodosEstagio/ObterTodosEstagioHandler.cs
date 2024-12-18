using AutoMapper;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;

public class ObterTodosEstagioHandler : IRequestHandler<ObterTodosEstagioRequest, List<ObterTodosEstagioResponse>>
{
    private readonly IEstagioRepository _estagioRepository;
    private readonly IMapper _mapper;

    public ObterTodosEstagioHandler(IEstagioRepository estagioRepository, IMapper mapper)
    {
        _estagioRepository = estagioRepository;
        _mapper = mapper;
    }

    public async Task<List<ObterTodosEstagioResponse>> Handle(ObterTodosEstagioRequest request, CancellationToken cancellationToken)
    {
        var estagios = await _estagioRepository.ObterTodosAsync(cancellationToken);
        return _mapper.Map<List<ObterTodosEstagioResponse>>(estagios);
    } 
}