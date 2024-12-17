using MediatR;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.AdicionarOrientador
{
    public sealed record AdicionarOrientadorRequest(
        string Nome, string Email, string Telefone
    ) : IRequest<AdicionarOrientadorResponse>;
}
