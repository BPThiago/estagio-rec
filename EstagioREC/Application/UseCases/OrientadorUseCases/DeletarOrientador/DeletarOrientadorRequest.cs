using EstagioREC.Application.DTOs;
using MediatR;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.DeletarOrientador
{
    public sealed record DeletarOrientadorRequest(
        int Id
    ) : IRequest<OrientadorResponse>;
}