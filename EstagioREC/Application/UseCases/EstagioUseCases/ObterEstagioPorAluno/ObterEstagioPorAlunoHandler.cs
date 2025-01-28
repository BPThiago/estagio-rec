using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorAluno;

public class ObterEstagioPorAlunoHandler : IRequestHandler<ObterEstagioPorAlunoRequest, List<EstagioResponse>>
{
    private readonly IEstagioRepository _estagioRepository;
    private readonly IMapper _mapper;

    public ObterEstagioPorAlunoHandler(IEstagioRepository estagioRepository, IMapper mapper)
    {
        _estagioRepository = estagioRepository;
        _mapper = mapper;
    }

    public async Task<List<EstagioResponse>> Handle(ObterEstagioPorAlunoRequest request, CancellationToken cancellationToken)
    {
        var estagios = await _estagioRepository.ObterPorAlunoAsync(request.AlunoId, cancellationToken);
        return _mapper.Map<List<EstagioResponse>>(estagios);
    } 
}
