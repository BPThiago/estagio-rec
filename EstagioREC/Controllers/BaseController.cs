using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstagioREC.Controller
{
    public class BaseController<ObterTodosRequest, ObterRequest, CriarRequest, AtualizarRequest, DeletarRequest, Response> : ControllerBase
        where Response : BaseResponse
        where ObterTodosRequest : IRequest<List<Response>>, new()
        where ObterRequest : IRequest<Response>
        where CriarRequest : IRequest<Response>
        where AtualizarRequest : IRequest<Response>
        where DeletarRequest : IRequest<Response>
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public BaseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Obter(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(_mapper.Map<ObterRequest>(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<Response>>> ObterTodos(CancellationToken cancellationToken) 
        {
            var response = await _mediator.Send(new ObterTodosRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Criar(CriarRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Atualizar(int id, AtualizarRequest request, CancellationToken cancellationToken) 
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Deletar(int? id, DeletarRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(_mapper.Map<DeletarRequest>(id), cancellationToken);
            return Ok(response);
        }
    }
}