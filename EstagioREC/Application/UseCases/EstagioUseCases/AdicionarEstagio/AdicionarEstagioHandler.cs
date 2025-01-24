using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.AdicionarEstagio
{
    public class AdicionarEstagioHandler : AdicionarHandler<
        AdicionarEstagioRequest,
        EstagioResponse,
        Estagio,
        IEstagioRepository
    >
    {
        public AdicionarEstagioHandler(IEstagioRepository repository, IMapper mapper) : base(repository, mapper) 
        {
        }
    }
}


