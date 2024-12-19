using AutoMapper;
using EstagioREC.Application.UseCases.AlunoUseCases.AdicionarAluno;
using EstagioREC.Application.UseCases.AlunoUseCases.AtualizarAluno;
using EstagioREC.Application.UseCases.AlunoUseCases.DeletarAluno;
using EstagioREC.Application.UseCases.AlunoUseCases.ObterAluno;
using EstagioREC.Application.UseCases.AlunoUseCases.ObterTodosAluno;
using EstagioREC.Application.UseCases.BaseUseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstagioREC.Controller
{
    [ApiController]
    [Route("alunos")]
    public class AlunoController : BaseController
    <ObterTodosAlunoRequest,
    ObterAlunoRequest,
    AdicionarAlunoRequest,
    AtualizarAlunoRequest,
    DeletarAlunoRequest,
    AlunoResponse>
    {
        public AlunoController(IMediator mediator, IMapper mapper) : base(mediator, mapper) 
        { 
        }
    }
}