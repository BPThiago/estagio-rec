using AutoMapper;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.ObterAluno;

public sealed class ObterAlunoHandler : IRequestHandler<ObterAlunoRequest, ObterAlunoResponse>
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly IMapper _mapper;

    public ObterAlunoHandler(IAlunoRepository alunoRepository, IMapper mapper)
    {
        _alunoRepository = alunoRepository;
        _mapper = mapper;
    }

    public async Task<ObterAlunoResponse> Handle(ObterAlunoRequest request, CancellationToken cancellationToken)
    {
        var aluno = await _alunoRepository.ObterPorIdAsync(request.Id);
        return _mapper.Map<ObterAlunoResponse>(aluno);
    }
}