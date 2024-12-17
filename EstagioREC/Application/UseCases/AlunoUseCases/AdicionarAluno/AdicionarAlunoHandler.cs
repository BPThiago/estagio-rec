using AutoMapper;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.AlunoUseCases.AdicionarAluno
{
    public class AdicionarAlunoHandler : IRequestHandler<AdicionarAlunoRequest, AdicionarAlunoResponse>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AdicionarAlunoHandler(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper; 
        }

        public async Task<AdicionarAlunoResponse> Handle(AdicionarAlunoRequest request, CancellationToken cancellationToken)
        {
            var aluno = _mapper.Map<Aluno>(request);
            await _alunoRepository.AdicionarAsync(aluno);
            return _mapper.Map<AdicionarAlunoResponse>(aluno);
        }
    }
}