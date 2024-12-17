using AutoMapper;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.DeletarAluno;

    public class DeletarAlunoHandler : IRequestHandler<DeletarAlunoRequest, DeletarAlunoResponse>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public DeletarAlunoHandler(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<DeletarAlunoResponse> Handle(DeletarAlunoRequest request,
            CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(request.Id);

            if (aluno is null)
                return default;
        
            await _alunoRepository.DeletarAsync(aluno);
        
            return _mapper.Map<DeletarAlunoResponse>(aluno);
        }
    }