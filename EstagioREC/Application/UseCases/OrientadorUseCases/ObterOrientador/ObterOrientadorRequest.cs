using EstagioREC.Application.DTOs;
using MediatR;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterOrientador
{
    public sealed record ObterOrientadorRequest(
        int Id
    ) : IRequest<OrientadorResponse>;
}