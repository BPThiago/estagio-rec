using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorEmpresa;

public class ObterEstagioPorEmpresaHandler : IRequestHandler<ObterEstagioPorEmpresaRequest, List<EstagioResponse>>
{
    private readonly IEstagioRepository _estagioRepository;
    private readonly IMapper _mapper;

    public ObterEstagioPorEmpresaHandler(IEstagioRepository estagioRepository, IMapper mapper)
    {
        _estagioRepository = estagioRepository;
        _mapper = mapper;
    }

    public async Task<List<EstagioResponse>> Handle(ObterEstagioPorEmpresaRequest request, CancellationToken cancellationToken)
    {
        var estagios = await _estagioRepository.ObterPorEmpresaAsync(request.EmpresaId, cancellationToken);
        return _mapper.Map<List<EstagioResponse>>(estagios);
    } 
}
