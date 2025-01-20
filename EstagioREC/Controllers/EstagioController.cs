using MediatR;
using Microsoft.AspNetCore.Mvc;
using EstagioREC.Application.UseCases.EstagioUseCases.AdicionarEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.AtualizarEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.DeletarEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagio;
using EstagioREC.Application.UseCases.BaseUseCases;
using AutoMapper;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorAluno;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorOrientador;
using EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorEmpresa;

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

        [HttpGet("aluno/{alunoId}")]
        public async Task<ActionResult<List<EstagioResponse>>> ObterEstagioPorAluno(int alunoId, CancellationToken cancellationToken) 
        {
            var response = await _mediator.Send(new ObterEstagioPorAlunoRequest(alunoId), cancellationToken);
            return Ok(response);
        }

        [HttpGet("orientador/{orientadorId}")]
        public async Task<ActionResult<List<EstagioResponse>>> ObterEstagioPorOrientador(int orientadorId, CancellationToken cancellationToken) 
        {
            var response = await _mediator.Send(new ObterEstagioPorOrientadorRequest(orientadorId), cancellationToken);
            return Ok(response);
        }

        [HttpGet("empresa/{empresaId}")]
        public async Task<ActionResult<List<EstagioResponse>>> ObterEstagioPorEmpresa(int empresaId, CancellationToken cancellationToken) 
        {
            var response = await _mediator.Send(new ObterEstagioPorEmpresaRequest(empresaId), cancellationToken);
            return Ok(response);
        }
    }
}

