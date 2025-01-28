using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.AdicionarOrientador
{
    public class AdicionarOrientadorHandler : AdicionarHandler<
        AdicionarOrientadorRequest,
        OrientadorResponse,
        Orientador,
        IOrientadorRepository
    >
    {
        public AdicionarOrientadorHandler(IOrientadorRepository repository, IMapper mapper) : base(repository, mapper) 
        {
        }
    }
}
