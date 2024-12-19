using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.ObterTodosAluno;

public sealed class ObterTodosAlunoHandler : IRequestHandler<ObterTodosAlunoRequest, List<AlunoResponse>>
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly IMapper _mapper;

    public ObterTodosAlunoHandler(IAlunoRepository alunoRepository, IMapper mapper)
    {
        _alunoRepository = alunoRepository;
        _mapper = mapper;
    }

    public async Task<List<AlunoResponse>> Handle(ObterTodosAlunoRequest request, CancellationToken cancellationToken)
    { 
        var alunos = await _alunoRepository.ObterTodosAsync(cancellationToken);
        return _mapper.Map<List<AlunoResponse>>(alunos);
    }
}