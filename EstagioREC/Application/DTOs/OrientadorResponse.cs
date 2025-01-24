using EstagioREC.Application.UseCases.BaseUseCases;

namespace EstagioREC.Application.DTOs
{
    public sealed record OrientadorResponse : BaseResponse
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
