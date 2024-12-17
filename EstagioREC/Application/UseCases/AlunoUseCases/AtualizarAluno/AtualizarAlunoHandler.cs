using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;

namespace EstagioREC.Application.UseCases.AlunoUseCases.AtualizarAluno;

public class AtualizarAlunoHandler : IRequestHandler<AtualizarAlunoRequest, AtualizarAlunoResponse>
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly IMapper _mapper;

    public AtualizarAlunoHandler(IAlunoRepository alunoRepository, IMapper mapper)
    {
        _alunoRepository = alunoRepository;
        _mapper = mapper;
    }

    public async Task<AtualizarAlunoResponse> Handle(AtualizarAlunoRequest request,
        CancellationToken cancellationToken)
    {
        var aluno = await _alunoRepository.ObterPorIdAsync(request.Id);

        if (aluno is null)
            return default;
        
        aluno.Nome = request.Nome;
        aluno.Matricula = request.Matricula;

        await _alunoRepository.AtualizarAsync(aluno);
        
        return _mapper.Map<AtualizarAlunoResponse>(aluno);
    }
}