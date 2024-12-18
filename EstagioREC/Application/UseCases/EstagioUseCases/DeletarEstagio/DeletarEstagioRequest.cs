using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.DeletarEstagio;

public sealed record DeletarEstagioRequest
(
    int Id
) : IRequest<DeletarEstagioResponse>;