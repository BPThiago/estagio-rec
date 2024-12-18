using EstagioREC.Application.UseCases.EmpresaUseCases.AdicionarEmpresa;
using EstagioREC.Application.UseCases.EmpresaUseCases.AtualizarEmpresa;
using EstagioREC.Application.UseCases.EmpresaUseCases.DeletarEmpresa;
using EstagioREC.Application.UseCases.EmpresaUseCases.ObterEmpresa;
using EstagioREC.Application.UseCases.EmpresaUseCases.ObterTodosEmpresa;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstagioREC.Controller
{
    [ApiController]
    [Route("/")]
    public class EmpresaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpresaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("empresas/{id}")]
        public async Task<ActionResult<ObterEmpresaResponse>> ObterEmpresa(int id, CancellationToken cancellationToken)
        {
            var obterEmpresaRequest = new ObterEmpresaRequest(id);
            var response = await _mediator.Send(obterEmpresaRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("empresas/")]
        public async Task<ActionResult<List<ObterTodosEmpresaResponse>>> ListarEmpresas(CancellationToken cancellationToken) 
        {
            var response = await _mediator.Send(new ObterTodosEmpresaRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost("empresas/")]
        public async Task<ActionResult<AdicionarEmpresaResponse>> CriarEmpresa(AdicionarEmpresaRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("empresas/{id}")]
        public async Task<ActionResult<AtualizarEmpresaResponse>> AtualizarEmpresa(int id, AtualizarEmpresaRequest request, CancellationToken cancellationToken) 
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("empresas/{id}")]
        public async Task<ActionResult<DeletarEmpresaResponse>> DeletarEmpresa(int? id, DeletarEmpresaRequest request, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var deletarEmpresaRequest = new DeletarEmpresaRequest(id.Value);

            var response = await _mediator.Send(deletarEmpresaRequest, cancellationToken);
            return Ok(response);
        }
    }
}