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
    [Route("/")]
    public class OrientadorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrientadorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("orientadores/{id}")]
        public async Task<ActionResult<ObterOrientadorResponse>> ObterOrientador(int id, CancellationToken cancellationToken)
        {
            var obterOrientadorRequest = new ObterOrientadorRequest(id);
            var response = await _mediator.Send(obterOrientadorRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("orientadores/")]
        public async Task<ActionResult<List<ObterTodosOrientadorResponse>>> ListarOrientadores(CancellationToken cancellationToken) 
        {
            var response = await _mediator.Send(new ObterTodosOrientadorRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost("orientadores/")]
        public async Task<ActionResult<AdicionarOrientadorResponse>> CriarOrientador(AdicionarOrientadorRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("orientadores/{id}")]
        public async Task<ActionResult<AtualizarOrientadorResponse>> AtualizarOrientador(int id, AtualizarOrientadorRequest request, CancellationToken cancellationToken) 
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("orientadores/{id}")]
        public async Task<ActionResult<DeletarOrientadorResponse>> DeletarOrientador(int? id, DeletarOrientadorRequest request, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var deletarOrientadorRequest = new DeletarOrientadorRequest(id.Value);

            var response = await _mediator.Send(deletarOrientadorRequest, cancellationToken);
            return Ok(response);
        }
    }
}