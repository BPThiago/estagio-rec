using EstagioREC.Application.UseCases.BaseUseCases;
using EstagioREC.Domain.Enums;
using MediatR;

namespace EstagioREC.Application.UseCases.EstagioUseCases.ObterTodosEstagio;

public sealed record ObterTodosEstagioRequest
    : IRequest<List<EstagioResponse>>;