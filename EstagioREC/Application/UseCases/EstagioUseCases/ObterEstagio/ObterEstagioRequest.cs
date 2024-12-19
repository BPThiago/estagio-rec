using EstagioREC.Application.UseCases.BaseUseCases;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagio;

public sealed record ObterEstagioRequest
(
    int Id
) : IRequest<EstagioResponse>;