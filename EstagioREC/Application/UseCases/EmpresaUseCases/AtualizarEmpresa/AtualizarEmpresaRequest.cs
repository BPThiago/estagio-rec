using EstagioREC.Application.DTOs;
using MediatR;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.AtualizarEmpresa
{
    public sealed record AtualizarEmpresaRequest(
        int Id,
        string Nome
    ) : IRequest<EmpresaResponse>;
}