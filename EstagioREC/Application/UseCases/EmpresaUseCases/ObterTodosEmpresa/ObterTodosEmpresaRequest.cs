using MediatR;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterTodosEmpresa
{
    public sealed record ObterTodosEmpresaRequest 
        : IRequest<List<ObterTodosEmpresaResponse>>;
}