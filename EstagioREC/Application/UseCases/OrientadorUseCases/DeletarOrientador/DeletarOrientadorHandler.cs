using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;
using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Application.DTOs;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.DeletarOrientador;

public class DeletarOrientadorHandler : DeletarHandler<
        DeletarOrientadorRequest,
        OrientadorResponse,
        Orientador,
        IOrientadorRepository
    >
{
    public DeletarOrientadorHandler(IOrientadorRepository repository, IMapper mapper) : base(repository, mapper) 
    {
    }
}