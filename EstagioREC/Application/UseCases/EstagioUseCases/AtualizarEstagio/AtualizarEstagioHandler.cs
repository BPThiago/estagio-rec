using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.AtualizarEstagio;

public class AtualizarEstagioHandler : AtualizarHandler<
        AtualizarEstagioRequest,
        EstagioResponse,
        Estagio,
        IEstagioRepository
    >
{
    public AtualizarEstagioHandler(IEstagioRepository repository, IMapper mapper) : base(repository, mapper) 
    {
    }
}