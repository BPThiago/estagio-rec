using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.DeletarAluno;

    public class DeletarAlunoHandler : IRequestHandler<DeletarAlunoRequest, AlunoResponse>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public DeletarAlunoHandler(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<AlunoResponse> Handle(DeletarAlunoRequest request,
            CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(request.Id, cancellationToken);

            if (aluno is null)
                return default;
        
            await _alunoRepository.DeletarAsync(aluno, cancellationToken);
        
            return _mapper.Map<AlunoResponse>(aluno);
        }
    }