using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Application.UseCases.EstagioUseCases.DeletarEstagio;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.DeletarEstagio;

public class DeletarEstagioHandler : DeletarHandler<
        DeletarEstagioRequest,
        EstagioResponse,
        Estagio,
        IEstagioRepository
    >
{
    public DeletarEstagioHandler(IEstagioRepository repository, IMapper mapper) : base(repository, mapper) 
    {
    }
}