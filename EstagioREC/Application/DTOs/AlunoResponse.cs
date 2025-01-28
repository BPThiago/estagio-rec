using EstagioREC.Application.UseCases.BaseUseCases;

namespace EstagioREC.Application.DTOs
{
    public sealed record AlunoResponse : BaseResponse
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
    }
}
