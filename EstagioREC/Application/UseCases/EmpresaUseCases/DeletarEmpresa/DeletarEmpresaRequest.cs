using EstagioREC.Application.DTOs;
using MediatR;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.DeletarEmpresa
{
    public sealed record DeletarEmpresaRequest(
        int Id
    ) : IRequest<EmpresaResponse>;
}