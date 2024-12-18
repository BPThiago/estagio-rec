using MediatR;

namespace EstagioREC.Application.UseCases.EmpresaUseCases.AdicionarEmpresa
{ 
    public sealed record AdicionarEmpresaRequest(
        string nome
        ) : IRequest<AdicionarEmpresaResponse>;
}
