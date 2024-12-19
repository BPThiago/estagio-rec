using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;

public class ObterTodosEstagioHandler : ObterTodosHandler<
        ObterTodosEstagioRequest,
        EstagioResponse,
        Estagio,
        IEstagioRepository
    >
{
    public ObterTodosEstagioHandler(IEstagioRepository repository, IMapper mapper) : base(repository, mapper) 
    {
    }
}