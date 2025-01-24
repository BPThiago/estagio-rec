using EstagioREC.Application.DTOs;
using MediatR;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.AdicionarEmpresa
{
    public sealed record AdicionarEmpresaRequest(
        string Nome
        ) : IRequest<EmpresaResponse>;
}
