using EstagioREC.Application.UseCases.EstagioUseCases.AdicionarEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EstagioREC.Application.UseCases.EstagioUseCases.AdicionarEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.AtualizarEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.DeletarEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;

namespace EstagioREC.Controller
{
    [ApiController]
    [Route("/")]
    public class EstagioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstagioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("estagios/{id}")]
        public async Task<ActionResult<ObterEstagioResponse>> ObterEstagio(int id, CancellationToken cancellationToken)
        {
            var obterEstagioRequest = new ObterEstagioRequest(id);
            var response = await _mediator.Send(obterEstagioRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("estagios/")]
        public async Task<ActionResult<List<ObterTodosEstagioResponse>>> ListarEstagios(
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTodosEstagioRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost("estagios/")]
        public async Task<ActionResult<AdicionarEstagioResponse>> CriarEstagio(AdicionarEstagioRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("estagios/{id}")]
        public async Task<ActionResult<AtualizarEstagioResponse>> Atualizarestagio(int id, AtualizarEstagioRequest request, CancellationToken cancellationToken) 
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        [HttpDelete("estagios/{id}")]
        public async Task<ActionResult<DeletarEstagioResponse>> DeletarEstagio(int? id, DeletarEstagioRequest request, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var deletarEstagioRequest = new DeletarEstagioRequest(id.Value);

            var response = await _mediator.Send(deletarEstagioRequest, cancellationToken);
            return Ok(response);
        }
    }
}

