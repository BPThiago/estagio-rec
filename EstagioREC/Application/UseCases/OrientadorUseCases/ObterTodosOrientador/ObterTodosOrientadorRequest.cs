using EstagioREC.Application.UseCases.BaseUseCases;
using MediatR;

namespace EstagioREC.Application.UseCases.OrientadorUseCases.ObterTodosOrientador
{
    public sealed record ObterTodosOrientadorRequest 
        : IRequest<List<OrientadorResponse>>;
}