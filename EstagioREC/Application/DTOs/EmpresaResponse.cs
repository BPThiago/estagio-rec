using EstagioREC.Application.UseCases.BaseUseCases;

namespace EstagioREC.Application.DTOs
{
    public sealed record EmpresaResponse : BaseResponse
    {
        public string Nome { get; set; }
    }
}
