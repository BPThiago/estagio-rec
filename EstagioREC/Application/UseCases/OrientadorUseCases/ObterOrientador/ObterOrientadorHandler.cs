using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterOrientador;

public sealed class ObterOrientadorHandler : ObterHandler<
        ObterOrientadorRequest,
        OrientadorResponse,
        Orientador,
        IOrientadorRepository
    >
{
    public ObterOrientadorHandler(IOrientadorRepository repository, IMapper mapper) : base(repository, mapper) 
    {
    }
}