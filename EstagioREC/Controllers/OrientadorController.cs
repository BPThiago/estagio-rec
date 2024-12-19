using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Application.UseCases.OrientadorUseCases.AdicionarOrientador;
using EstagioREC.Application.UseCases.OrientadorUseCases.AtualizarOrientador;
using EstagioREC.Application.UseCases.OrientadorUseCases.DeletarOrientador;
using EstagioREC.Application.UseCases.OrientadorUseCases.ObterOrientador;
using EstagioREC.Application.UseCases.OrientadorUseCases.ObterTodosOrientador;
using EstagioREC.Domain;
using EstagioREC.Persistence.Repository.Interfaces;
using Google.Apis.Sheets.v4.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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