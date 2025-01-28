using AutoMapper;
using EstagioREC.Application.DTOs;
using EstagioREC.Application.UseCases.OrientadorUseCases.AdicionarOrientador;
using EstagioREC.Application.UseCases.OrientadorUseCases.AtualizarOrientador;
using EstagioREC.Application.UseCases.OrientadorUseCases.DeletarOrientador;
using EstagioREC.Application.UseCases.OrientadorUseCases.ObterOrientador;
using EstagioREC.Application.UseCases.OrientadorUseCases.ObterTodosOrientador;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstagioREC.Controller
{
    [ApiController]
    [Route("orientadores")]
    public class OrientadorController : BaseController
    <ObterTodosOrientadorRequest,
    ObterOrientadorRequest,
    AdicionarOrientadorRequest,
    AtualizarOrientadorRequest,
    DeletarOrientadorRequest,
    OrientadorResponse>
    {
        public OrientadorController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}


