using EstagioREC.Application.UseCases.BaseUseCases;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagioPorOrientador;

public sealed record ObterEstagioPorOrientadorRequest
(
    int OrientadorId
) : IRequest<List<EstagioResponse>>;