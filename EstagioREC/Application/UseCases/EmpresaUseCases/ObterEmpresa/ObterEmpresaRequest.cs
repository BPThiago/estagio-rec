using EstagioREC.Application.UseCases.BaseUseCases;
using MediatR;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.ObterEmpresa
{
    public sealed record ObterEmpresaRequest(
        int Id
    ) : IRequest<EmpresaResponse>;
}