using EstagioREC.Application.DTOs;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterEstagio;

public sealed record ObterEstagioRequest
(
    int Id
) : IRequest<EstagioResponse>;