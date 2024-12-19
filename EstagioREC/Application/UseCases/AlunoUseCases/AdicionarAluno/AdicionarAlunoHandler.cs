using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;

namespace EstagioREC.Application.UseCases.AlunoUseCases.AdicionarAluno
{
    public class AdicionarAlunoHandler : AdicionarHandler<
        AdicionarAlunoRequest,
        AlunoResponse,
        Aluno,
        IAlunoRepository
    >
    {
        public AdicionarAlunoHandler(IAlunoRepository repository, IMapper mapper) : base(repository, mapper) 
        {
        }
    }
}
