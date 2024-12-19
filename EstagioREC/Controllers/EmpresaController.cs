using AutoMapper;
using EstagioREC.Application.UseCases.BaseUseCases;
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
    [Route("empresas")]
    public class EmpresaController : BaseController
    <ObterTodosEmpresaRequest,
    ObterEmpresaRequest,
    AdicionarEmpresaRequest,
    AtualizarEmpresaRequest,
    DeletarEmpresaRequest,
    EmpresaResponse>
    {
        public EmpresaController(IMediator mediator, IMapper mapper) : base(mediator, mapper) 
        { 
        }
    }
}