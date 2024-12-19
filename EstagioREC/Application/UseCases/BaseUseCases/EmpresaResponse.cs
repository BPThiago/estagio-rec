namespace EstagioREC.Application.UseCases.BaseUseCases
{
    public sealed record EmpresaResponse : BaseResponse
    {
        public string Nome { get; set; }
    }
}
