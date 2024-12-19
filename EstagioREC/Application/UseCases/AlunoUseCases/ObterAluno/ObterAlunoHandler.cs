using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.ObterAluno;

public sealed class ObterAlunoHandler : IRequestHandler<ObterAlunoRequest, AlunoResponse>
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly IMapper _mapper;

    public ObterAlunoHandler(IAlunoRepository alunoRepository, IMapper mapper)
    {
        _alunoRepository = alunoRepository;
        _mapper = mapper;
    }

    public async Task<AlunoResponse> Handle(ObterAlunoRequest request, CancellationToken cancellationToken)
    {
        var aluno = await _alunoRepository.ObterPorIdAsync(request.Id, cancellationToken);
        return _mapper.Map<AlunoResponse>(aluno);
    }
}