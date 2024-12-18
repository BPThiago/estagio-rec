using EstagioREC.Domain.Enums;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagio;

public sealed record ObterEstagioRequest
(
    int Id
) : IRequest<ObterEstagioResponse>;