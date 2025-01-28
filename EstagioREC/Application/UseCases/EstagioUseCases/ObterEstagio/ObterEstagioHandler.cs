using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagio;

public sealed class ObterEstagioHandler : ObterHandler<
        ObterEstagioRequest,
        EstagioResponse,
        Estagio,
        IEstagioRepository
    >
{
    public ObterEstagioHandler(IEstagioRepository repository, IMapper mapper) : base(repository, mapper) 
    {
    }
}