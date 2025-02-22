using EstagioREC.Application.DTOs;
using MediatR;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.AtualizarOrientador
{
    public sealed record AtualizarOrientadorRequest(
        int Id,
        string Nome,
        string Email,
        string Telefone
    ) : IRequest<OrientadorResponse>;
}