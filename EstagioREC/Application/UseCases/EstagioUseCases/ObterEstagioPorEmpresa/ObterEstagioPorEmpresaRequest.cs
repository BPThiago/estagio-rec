using EstagioREC.Application.UseCases.BaseUseCases;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorEmpresa;

public sealed record ObterEstagioPorEmpresaRequest
(
    int EmpresaId
) : IRequest<List<EstagioResponse>>;