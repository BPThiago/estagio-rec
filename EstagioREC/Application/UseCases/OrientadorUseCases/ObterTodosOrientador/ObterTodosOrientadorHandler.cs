using EstagioREC.Persistence.Repository.Interfaces;
using AutoMapper;
using MediatR;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterTodosOrientador;

public sealed class ObterTodosOrientadorHandler : ObterTodosHandler<
        ObterTodosOrientadorRequest,
        OrientadorResponse,
        Orientador,
        IOrientadorRepository
    >
{
    public ObterTodosOrientadorHandler(IOrientadorRepository repository, IMapper mapper) : base(repository, mapper) 
    {
    }
}