using MediatR;
using Microsoft.AspNetCore.Mvc;
using EstagioREC.Application.UseCases.EstagioUseCases.AdicionarEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.AtualizarEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.DeletarEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagio;
using EstagioREC.Application.UseCases.BaseUseCases;
using AutoMapper;

namespace EstagioREC.Controller
{
    [ApiController]
    [Route("estagios")]
    public class EstagioController : BaseController
    <ObterTodosEstagioRequest,
    ObterEstagioRequest,
    AdicionarEstagioRequest,
    AtualizarEstagioRequest,
    DeletarEstagioRequest,
    EstagioResponse>
    {
        public EstagioController(IMediator mediator, IMapper mapper) : base(mediator, mapper) 
        { 
        }
    }
}

