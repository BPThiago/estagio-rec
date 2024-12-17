using EstagioREC.Application.UseCases.AlunoUseCases.AdicionarAluno;
using EstagioREC.Application.UseCases.AlunoUseCases.AtualizarAluno;
using EstagioREC.Application.UseCases.AlunoUseCases.DeletarAluno;
using EstagioREC.Application.UseCases.AlunoUseCases.ObterAluno;
using EstagioREC.Application.UseCases.AlunoUseCases.ObterTodosAluno;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstagioREC.Controller
{
    [ApiController]
    [Route("/")]
    public class AlunoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlunoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("alunos/{id}")]
        public async Task<ActionResult<ObterAlunoResponse>> ObterAluno(int id, CancellationToken cancellationToken)
        {
            var obterAlunoRequest = new ObterAlunoRequest(id);
            var response = await _mediator.Send(obterAlunoRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("alunos/")]
        public async Task<ActionResult<List<ObterTodosAlunoResponse>>> ListarAlunos(CancellationToken cancellationToken) 
        {
            var response = await _mediator.Send(new ObterTodosAlunoRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost("alunos/")]
        public async Task<ActionResult<AdicionarAlunoResponse>> CriarAluno(AdicionarAlunoRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("alunos/{id}")]
        public async Task<ActionResult<AtualizarAlunoResponse>> AtualizarAluno(int id, AtualizarAlunoRequest request, CancellationToken cancellationToken) 
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("alunos/{id}")]
        public async Task<ActionResult<DeletarAlunoResponse>> DeletarAluno(int? id, DeletarAlunoRequest request, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var deletarAlunoRequest = new DeletarAlunoRequest(id.Value);

            var response = await _mediator.Send(deletarAlunoRequest, cancellationToken);
            return Ok(response);
        }
    }
}